using MainProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.BLL.Models
{
    public class IndexViewModel
    {
        public IEnumerable<CourseEntity> Courses { get; set; }
        public IEnumerable<SkillEntity> Skills { get; set; }
        public IEnumerable<MaterialEntity> Materials { get; set; }
        public IEnumerable<UserEntity> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
