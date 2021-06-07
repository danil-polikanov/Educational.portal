using Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class CourseRepository : ICourseRepository
    {
        List<CourseEntity> courses = new List<CourseEntity>();
        private readonly string defaultPathCourse = "Courses.txt";
        public void SaveList()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(courses.OfType<CourseEntity>());
            File.WriteAllText(defaultPathCourse, jsonString);
        }
        public List<CourseEntity> ShowCourses()
        {
            var result = new List<CourseEntity>();
            if (!File.Exists(defaultPathCourse))
            {
                File.Create(defaultPathCourse).Close();
            }
            string jsonString;
            jsonString = File.ReadAllText(defaultPathCourse);
            if (jsonString != "")
            {
                result.AddRange(JsonSerializer.Deserialize<List<CourseEntity>>(jsonString));
            }
            return result;
        }
        public bool AddCourse(CourseEntity course)
        {
            courses.Add(course);
            SaveList();
            return true;
        }
        public bool UpdateCourse(CourseEntity course)
        {
            {
                List<CourseEntity> courseList = ShowCourses();
                int index = courseList.FindIndex(x => x.Id == course.Id);
                if (index != -1)
                {
                    courseList[index] = course;
                    var jsonString = JsonSerializer.Serialize(courseList);
                    File.WriteAllText(defaultPathCourse, jsonString);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
