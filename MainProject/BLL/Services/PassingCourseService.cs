using Domain.Entity;
using Domain.IRepository;
using MainProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class PassingCourseService : IPassingCourseService
    {
        private readonly IRepository<CourseEntity> _courseRepository;
        private readonly IRepository<MaterialEntity> _materialRepository;
        private readonly IRepository<SkillEntity> _skillRepository;
        private readonly IRepository<PassingCourse> _passingCourseRepository;
        private readonly IRepository<UserEntity> _userRepository;
        public PassingCourseService(IRepository<MaterialEntity> materialRepository, IRepository<SkillEntity> skiilRepository, IRepository<CourseEntity> courseRepository, IRepository<PassingCourse> passingCourseRepository, IRepository<UserEntity> userRepository)
        {
            _courseRepository = courseRepository;
            _materialRepository = materialRepository;
            _skillRepository = skiilRepository;
            _passingCourseRepository = passingCourseRepository;
            _userRepository = userRepository;
        }
        public async virtual Task<IEnumerable<PassingCourse>> GetCoursesAsync(Func<PassingCourse, bool> predicate,
        params Expression<Func<PassingCourse, object>>[] includeProperties)
        {
            return await _passingCourseRepository.GetWithIncludeAsync(predicate,includeProperties);
        }

        public async virtual Task<IEnumerable<PassingCourse>> GetCoursesAsync(params Expression<Func<PassingCourse, object>>[] includeProperties)
        {
            return await _passingCourseRepository.GetWithIncludeAsync(includeProperties);
        }

        public async Task<bool> UpdateAsync(PassingCourse entity, CancellationToken cancellationToken = default)
        {
            var result = await _passingCourseRepository.UpdateAsync(entity, cancellationToken);
            return result;
        }

        public async virtual Task<bool> AddPassingCourse(CourseEntity course, UserEntity user, CancellationToken cancellationToken = default)
        {

            if (user.FinishedMaterials != null)
            {
                bool isUserHasThisMaterial = false;
                foreach (var i in user.FinishedMaterials) {
                    isUserHasThisMaterial = course.Materials.Any(x => x.Id == i.Id);
                }
                if (isUserHasThisMaterial)
                {
                    foreach (var i in user.SkillUserEnrollments)
                    {
                        foreach (var j in course.CourseSkillEnrollments) {
                            if (i.SkillId == j.SkillId) {
                                i.Level += 1;
                            }
                        }
                    }
                }


                foreach (var i in course.CourseSkillEnrollments)
                {
                    foreach (var x in user.SkillUserEnrollments)
                    {
                        if (i.RequirementLevel > x.Level && i.SkillId == x.SkillId)
                        {
                            throw new Exception("Недостаточный уровень умений");
                        }

                    }
                }
            }
            PassingCourse passingCourse = new PassingCourse();
            passingCourse.CourseId = course.Id;
            passingCourse.UserId = user.Id;
            await _passingCourseRepository.AddAsync(passingCourse, cancellationToken);
            return true;
        }

        public async Task<bool> PassCourse(PassingCourse TempCourse,UserEntity TempUser, int materialId, CancellationToken cancellationToken = default)
        {
            PassingCourse course = TempCourse;
            UserEntity user = TempUser;
            var material = (await _materialRepository.GetWithIncludeAsync(x => x.Id == materialId)).FirstOrDefault();
            user.FinishedMaterials.Add(material);

            if (course.Course.Materials != null)
            {
                course.Progress += course.Course.Materials.Count() / user.FinishedMaterials.Count() * 100;
            }
            else course.Progress = 100;
            if (course.Progress == 100)
            {
                course.IsComplete = true;
            }
            await _userRepository.UpdateAsync(user);
            return await _passingCourseRepository.UpdateAsync(course, cancellationToken);
        }
    }
}
