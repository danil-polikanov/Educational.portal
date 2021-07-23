using MainProject.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class SkillEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CreatedUserId { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<CourseEntity> Courses { get; set; }
        public virtual ICollection<SkillUserEnrollment> SkillUserEnrollments { get; set; }
        public virtual ICollection<CourseSkillEnrollment> CourseSkillEnrollments { get; set; }

        public virtual UserEntity CreatedByUser { get; set; }
        
        public SkillEntity()
        {

        }
        public SkillEntity(int CreatedUserId, string Name)
        {
            this.Name = Name;
            this.CreatedUserId = CreatedUserId;
        }
        public SkillEntity(int CreatedUserId, string Name, int SkillLevel)
        {
            this.Name = Name;
            this.CreatedUserId = CreatedUserId;
        }
    }
}
