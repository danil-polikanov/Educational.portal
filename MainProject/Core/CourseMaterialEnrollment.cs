using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class CourseMaterialEnrollment
    {
        public int CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }

        public int MaterialId { get; set; }
        public virtual MaterialEntity Material { get; set; }

    }
}
