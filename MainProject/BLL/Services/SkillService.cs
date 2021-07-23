using Domain.IRepository;
using MainProject.BLL.Interfaces.IServices;
using MainProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.BLL.Services
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<SkillEntity> _skillRepository;
        public SkillService(IRepository<SkillEntity> repository)
        {
            _skillRepository = repository;
        }
        public async Task<bool> AddSkillAsync(SkillEntity entity, CancellationToken cancellationToken = default)
        {
            await _skillRepository.AddAsync(entity, cancellationToken);
            return true;
        }
        public async virtual Task<IEnumerable<SkillEntity>> GetSkills(Func<SkillEntity, bool> predicate,
        params Expression<Func<SkillEntity, object>>[] includeProperties)
        {
            return await _skillRepository.GetWithIncludeAsync(predicate,includeProperties);
        }

        public async virtual Task<IEnumerable<SkillEntity>> GetSkills(params Expression<Func<SkillEntity, object>>[] includeProperties)
        {
            return await _skillRepository.GetWithIncludeAsync(includeProperties);
        }

        public async Task<bool> UpdateAsync(SkillEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _skillRepository.UpdateAsync(entity, cancellationToken);
            return result;
        }


    }
}
