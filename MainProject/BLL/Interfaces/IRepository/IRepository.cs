using Domain.Entity;
using MainProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> GetWithIncludeAsync(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> AddAsync(TEntity item, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TEntity item, CancellationToken cancellationToken = default);
        Task<bool> RemoveAsync(TEntity item, CancellationToken cancellationToken = default);
    }
}
