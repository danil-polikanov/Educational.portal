using MainProject.Core.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MainProject.Core
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<MaterialEntity> CreatedMaterials { get; set; }
        public virtual ICollection<MaterialEntity> FinishedMaterials { get; set; }
        public virtual ICollection<SkillEntity> CreatedSKills { get; set; }
        public virtual ICollection<SkillEntity> Skills { get; set; }
        public virtual ICollection<CourseEntity> CreatedCourses { get; set; }
        public virtual ICollection<PassingCourse> PassingCourses { get; set; }
        public virtual ICollection<SkillUserEnrollment> SkillUserEnrollments { get; set; }

        public UserEntity()
        {

        }
        public UserEntity(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
            FinishedMaterials = new List<MaterialEntity>();
            PassingCourses = new List<PassingCourse>();

        }
        public UserEntity(string Login, string Password, List<MaterialEntity> passingMaterials, List<PassingCourse> passingCourse, List<SkillEntity> userSKills)
        {
            this.Login = Login;
            this.Password = Password;
            FinishedMaterials = passingMaterials;
            PassingCourses = passingCourse;
        }
    }
}
