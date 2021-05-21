using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRefactoring.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Material> CourseMaterials { get; set; }
        public ICollection<Material> CourseSkill { get; set; }
        public ICollection<Material> CourseLearingSkills { get; set; }

    }
}
