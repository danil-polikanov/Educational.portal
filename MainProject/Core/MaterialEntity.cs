using MainProject.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class MaterialEntity : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        public int? CreatedUserId { get; set; }
        public virtual UserEntity CreatedByUser { get; set; }
        public virtual ICollection<CourseMaterialEnrollment> CourseMaterialEnrollments { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<CourseEntity> Courses { get; set; }

    }
}
