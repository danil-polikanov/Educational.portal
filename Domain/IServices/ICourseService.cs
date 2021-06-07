using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface ICourseService
    {
        public bool AddCourse(int userId, string name, string description,string materialsCourseName,string skillName);
        public List<CourseEntity> ShowCourses();
    }
}
