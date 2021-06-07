using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface ICourseRepository
    {
        public void SaveList();
        public List<CourseEntity> ShowCourses();
        public bool AddCourse(CourseEntity course);
    }
}
