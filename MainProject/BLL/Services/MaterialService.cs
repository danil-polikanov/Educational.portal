using Domain.Entity;
using Domain.IRepository;
using MainProject.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.BLL.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository<MaterialEntity> _materialRepository;

        public MaterialService(IRepository<MaterialEntity> repository)
        {
            _materialRepository = repository;
        }

        public async Task<bool> AddMaterialAsync(MaterialEntity entity, CancellationToken cancellationToken = default)
        {
            await _materialRepository.AddAsync(entity, cancellationToken);
            return true;
        }

        public async virtual Task<IEnumerable<MaterialEntity>> GetMaterialAsync(Func<MaterialEntity, bool> predicate,
        params Expression<Func<MaterialEntity, object>>[] includeProperties)
        {
            return await _materialRepository.GetWithIncludeAsync(predicate,includeProperties);
        }

        public async virtual Task<IEnumerable<MaterialEntity>> GetMaterialAsync(params Expression<Func<MaterialEntity, object>>[] includeProperties)
        {
            return await _materialRepository.GetWithIncludeAsync(includeProperties);
        }

        public async Task<bool> UpdateAsync(MaterialEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await _materialRepository.UpdateAsync(entity, cancellationToken);
            return result;
        }

    }
}