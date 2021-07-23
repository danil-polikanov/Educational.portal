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
    public class CourseService : ICourseService
    {
        private readonly IRepository<CourseEntity> _courseRepository;
        private readonly IRepository<MaterialEntity> _materialRepository;
        private readonly IRepository<SkillEntity> _skillRepository;
        private readonly IRepository<PassingCourse> _passingCourseRepository;
        public CourseService(IRepository<MaterialEntity> materialRepository, IRepository<SkillEntity> skiilRepository, IRepository<CourseEntity> courseRepository, IRepository<PassingCourse> passingCourseRepository)
        {
            _courseRepository = courseRepository;
            _materialRepository = materialRepository;
            _skillRepository = skiilRepository;
            _passingCourseRepository = passingCourseRepository;
        }
        public async Task<bool> AddCourseAsync(CourseEntity entity, CancellationToken cancellationToken = default)
        {   
            await _courseRepository.AddAsync(entity);
            return true;
        }
        public async virtual Task<IEnumerable<CourseEntity>> GetCoursesAsync(Func<CourseEntity, bool> predicate,
        params Expression<Func<CourseEntity, object>>[] includeProperties)
        {
            return await _courseRepository.GetWithIncludeAsync(predicate,includeProperties);
        }

        public async virtual Task<IEnumerable<CourseEntity>> GetCoursesAsync(params Expression<Func<CourseEntity, object>>[] includeProperties)
        {
            return await _courseRepository.GetWithIncludeAsync(includeProperties);
        }

        public async Task<bool> UpdateAsync(CourseEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _courseRepository.UpdateAsync(entity, cancellationToken);
            return result;
        }

    }
 
}
