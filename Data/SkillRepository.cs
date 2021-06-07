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
   public class SkillRepository:ISkillRepository
    {
        List<SkillEntity> skills = new List<SkillEntity>();
        private readonly string defaultPathSkill = "Skills.txt";
        public void SaveList()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(skills.OfType<SkillEntity>());
            File.WriteAllText(defaultPathSkill, jsonString);
        }
        public List<SkillEntity> ShowSkills()
        {
            var result = new List<SkillEntity>();
            if (!File.Exists(defaultPathSkill))
            {
                File.Create(defaultPathSkill).Close();
            }
            string jsonString;
            jsonString = File.ReadAllText(defaultPathSkill);
            if (jsonString != "")
            {
                result.AddRange(JsonSerializer.Deserialize<List<SkillEntity>>(jsonString));
            }
            return result;
        }
        public bool AddSkills(SkillEntity skill)
        {
            skills.Add(skill);
            SaveList();
            return true;
        }
    }
}
