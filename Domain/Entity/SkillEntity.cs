using Domain.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class SkillEntity : BaseEntity
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int UserId { get; set; }
        static public int counter = 1;
        public SkillEntity()
        {

        }
        public SkillEntity(int UserId, string Name)
        {
            this.Id = counter;
            this.Name = Name;
            this.UserId = UserId;
            counter++;
        }
        public SkillEntity(int UserId,string Name, int SkillLevel)
        {
            this.Id = counter;
            this.Name = Name;
            this.SkillLevel = SkillLevel;
            this.UserId = UserId;
            counter++;
        }
    }
}
