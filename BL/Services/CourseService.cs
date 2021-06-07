using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly ISkillRepository _skillRepository;
        List<CourseEntity> courses = new List<CourseEntity>();

        public CourseService(ICourseRepository repository,IMaterialRepository materialRepository,ISkillRepository skillRepository)
        {
            _courseRepository = repository;
            CourseEntity.counter += _courseRepository.ShowCourses().Count();
            courses.AddRange(_courseRepository.ShowCourses());
            _materialRepository = materialRepository;
            _skillRepository = skillRepository;
        }
        public bool AddCourse(int userId,string name,string description, string materialsCourseName,string skillName)
        {
           
            var materialResult = materialsCourseName.Split(",");
            var materialsList = _materialRepository.ShowMaterials();
            List<MaterialEntity> selectedMaterials = materialsList.Where(x => materialResult.Contains(x.Name)).Select(x => x).ToList();
            if (selectedMaterials == null)
                return false;
            var SkillResult = skillName.Split(':',',');
            var SkillsList = _skillRepository.ShowSkills();
            List<SkillEntity> selectedSkills = SkillsList.Where(x => SkillResult.Contains(x.Name)).Select(x => x).ToList();           
            if (selectedSkills == null)
                return false;
            int count = 1;
            foreach(var i in selectedSkills)
            { 
                i.SkillLevel = int.Parse(SkillResult[count]);
                count += 2;
            }
            CourseEntity course = new CourseEntity(userId, name, description, selectedMaterials, selectedSkills);
            _courseRepository.AddCourse(course);
            return true;
        }
        public List<CourseEntity> ShowCourses()
        {
            return _courseRepository.ShowCourses();
        }
    }
}
