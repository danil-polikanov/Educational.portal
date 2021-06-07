using Domain.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CourseEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        static public int counter=1;
        public List<MaterialEntity> Materials { get; set; }
        public List<SkillEntity> Skills { get; set; }
        public CourseEntity()
        {
        }
        public CourseEntity(int userId,string name, string description, List<MaterialEntity> materials, List<SkillEntity> Skills)
        {
            this.UserId = userId;
            this.Id = counter;
            this.Name = name;
            this.Description = description;
            this.Materials = materials;
            this.Skills = Skills;
            counter++;
        }
    }
}
