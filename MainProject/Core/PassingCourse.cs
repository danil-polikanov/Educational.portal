using MainProject.Core.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class PassingCourse:IEntity
    {
        public int Id { get; set; }
        public double Progress { get; set; }
        public bool IsComplete { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
        public int CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public PassingCourse()
        {

        }
        public PassingCourse(CourseEntity course, double progress, bool isComplete, int UserId)
        {
            this.UserId = UserId;
            CourseId = course.Id;
            Progress = progress;
            IsComplete = isComplete;
        }
    }
}
