using MainProject.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class CourseEntity : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано Описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        public int? CreatedByUserId { get; set; }
        public virtual ICollection<CourseSkillEnrollment> CourseSkillEnrollments { get; set; }
        public virtual ICollection<CourseMaterialEnrollment> CourseMaterialEnrollments { get; set; }
        public virtual ICollection<MaterialEntity> Materials { get; set; }
        public virtual ICollection<SkillEntity> Skills { get; set; }
        public virtual ICollection<PassingCourse> PassingCourses { get; set; }
        public virtual UserEntity CreatedByUser { get; set; }

        public CourseEntity()
        {
        }
        public CourseEntity(int CreaterByUserId, string name, string description, List<MaterialEntity> materials, List<SkillEntity> Skills)
        {
            CreatedByUserId = CreaterByUserId;
            Name = name;
            Description = description;
            Materials = materials;
            this.Skills = Skills;
        }
    }
}
