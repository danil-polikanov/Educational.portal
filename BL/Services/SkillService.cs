using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class SkillService:ISkillService
    {
        private readonly  ISkillRepository _skillRepository;
        List<SkillEntity> courses = new List<SkillEntity>();
        public SkillService(ISkillRepository repository)
        {
            _skillRepository = repository;
            SkillEntity.counter += _skillRepository.ShowSkills().Count();
            courses.AddRange(_skillRepository.ShowSkills());
        }
        public bool AddSkill(int userId,string name)
        {
            var SkillList = _skillRepository.ShowSkills();
            List<SkillEntity> selectedSkills = SkillList.Where(x => x.Name==name).Select(x => x).Select(x => x).ToList();
            if (selectedSkills == null)
                return false;
            SkillEntity skill = new SkillEntity(userId, name);
            _skillRepository.AddSkills(skill);
            return true;
        }
        public List<SkillEntity> ShowSkills()
        {
            return _skillRepository.ShowSkills();
        }
    }
}
