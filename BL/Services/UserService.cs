using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entity;

namespace BL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly ISkillRepository _skillRepository; 
        List<UserEntity> users = new List<UserEntity>();
        List<PassingCourse> userPassingCourses = new List<PassingCourse>();
        public UserService(IUserRepository repository, ICourseRepository courseRepository, IMaterialRepository materialRepository, ISkillRepository skillRepository)
        {
            _userRepository = repository;
            _materialRepository = materialRepository;
            _skillRepository = skillRepository;
            _courseRepository = courseRepository;
            foreach (var i in _userRepository.ShowUsers())
            {
                users.Add(new UserEntity(i.Login, i.Password));
            }      
            
        }
        public bool UserRegistration(string login, string password)
        {
            if (login == "Admin")
                return false;
            if (users.Any(u => u.Login != null))
            {
                if (users.Any(u => u.Login == login))
                    return false;
            }
            var user = new UserEntity(login, password);
            users.Add(user);
            _userRepository.UserRegistration(user);
            return true;
        }
        public bool AddPassingCourse(int userId,string name)
        {
            var courseResult = _courseRepository.ShowCourses();
            var userAddingCourseResult = _userRepository.ShowUsers();
            var courseMaterials = courseResult.Select(x => x.Materials);
            var userMaterials= userAddingCourseResult.Select(x => x.FinishedMaterials);
            var selectedCourse = courseResult.Where(x => name.Contains(x.Name)).Select(x => x).FirstOrDefault();
            var selectedUser = userAddingCourseResult.Where(x => x.Id == userId).Select(x => x).FirstOrDefault();
            var selectedUserSkills = selectedUser.UserSKills;
            if (selectedCourse == null)
                return false;
     
            foreach(var i in userAddingCourseResult)
            {
                if (i.PassingCourse.Where(x => name.Contains(x.Name)).Select(x => x) == null) return false;
            }

            //foreach (var i in userMaterials)
            //{
            //    foreach (var x in courseMaterials)
            //    {
            //        foreach (var y in selectedUserSkills)
            //            if (i.Name == x.Name)
            //            {
            //                y.SkillLevel += 1;
            //            }
            //    }
            //}
            var isUserHasThisMaterial=selectedCourse.Materials.Any(x => selectedUser.FinishedMaterials.Any(y => y.Name == x.Name));
            if (isUserHasThisMaterial)
            {
                foreach (var i in selectedUserSkills)
                {
                    i.SkillLevel += 1;
                }
            }

            foreach (var i in selectedCourse.Skills)
            {
                foreach (var x in selectedUser.UserSKills)
                {
                    if (i.Name == x.Name && i.SkillLevel > x.SkillLevel)
                    {
                        Console.WriteLine("Недостаточный уровень умений");
                        return false;
                    }
                        
                }
            }
            PassingCourse passingCourse=new PassingCourse(selectedCourse, 0, false);
            selectedUser.PassingCourse.Add(passingCourse);
            return _userRepository.AddPassingCourse(selectedUser);
        }

        public bool PassCourse(int userId,int courseId,int materialId)
        {
            var selectedUser = users.Where(x => x.Id == userId).FirstOrDefault();
            var PassUserCourse = selectedUser.PassingCourse.Where(x => x.Id == courseId).FirstOrDefault();
            var PassUserMaterial = PassUserCourse.Materials.Where(x => x.Id == materialId).FirstOrDefault();

            selectedUser.FinishedMaterials.Add(PassUserMaterial);

            var selectedUserMaterials = selectedUser.FinishedMaterials.Count();
            var UserCourseMaterials = PassUserCourse.Materials.Count();

            PassUserCourse.Progress = UserCourseMaterials / selectedUserMaterials * 100;        
            if (PassUserCourse.Progress == 100)
            {
                PassUserCourse.isComplete = true;
            }
                return _userRepository.PassCourse(selectedUser);
        }
        public UserEntity UserAuthentication(string login, string password)
        {
            return _userRepository.UserAuthentication(login, password);
        }
        public List<UserEntity> ShowUsers()
        {
            return _userRepository.ShowUsers();
        }
    }

}
