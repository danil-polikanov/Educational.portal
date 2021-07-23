using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class SkillUserEnrollment
    {
            public int UserId { get; set; }
            public UserEntity User { get; set; }

            public int SkillId { get; set; }
            public SkillEntity Skill { get; set; }

            public int Level { get; set; }

            public SkillUserEnrollment()
            { 
            }
    }
}
