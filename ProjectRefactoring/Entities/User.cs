using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRefactoring.Entities
{
    public class User
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public ICollection<Course> UserCourses  { get; set; }
       public ICollection<Skill> UserSkills { get; set; }

       public ICollection<Material> UserMaterials { get; set; }
       public ICollection<CreatedCourse> UserCreatedCourses { get; set; }
    }
}
