using MainProject.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface IMaterialService
    {
        Task<bool> AddMaterialAsync(MaterialEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<MaterialEntity>> GetMaterialAsync(Func<MaterialEntity, bool> predicate,
         params Expression<Func<MaterialEntity, object>>[] includeProperties);
        Task<IEnumerable<MaterialEntity>> GetMaterialAsync(params Expression<Func<MaterialEntity, object>>[] includeProperties);

        Task<bool> UpdateAsync(MaterialEntity entity, CancellationToken cancellationToken = default);
    }
}
