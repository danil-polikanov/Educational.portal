using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PassingCourse:CourseEntity
    {
        public double Progress { get; set; }
        public bool isComplete { get; set; }
       public PassingCourse(CourseEntity course,double progress,bool isComplete)
        {

            this.UserId = course.UserId;
            this.Id = course.Id;
            this.Name = course.Name;
            this.Description = course.Description;
            this.Materials = course.Materials;
            this.Skills = Skills;
            this.Progress = progress;
            this.isComplete = isComplete;
        }
    }
}
