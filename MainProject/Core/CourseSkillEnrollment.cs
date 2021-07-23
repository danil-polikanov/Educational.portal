using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class CourseSkillEnrollment
    {
        public int CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public int SkillId { get; set; }
        public virtual SkillEntity Skill { get; set; }
        public int RequirementLevel { get; set; }
        public CourseSkillEnrollment()
        {

        }
    }
}
