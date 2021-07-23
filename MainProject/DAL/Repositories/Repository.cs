using Domain.IRepository;
using MainProject.Core.Abstract;
using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async virtual Task<IEnumerable<TEntity>> GetWithIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> GetWithIncludeAsync(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = await Include(includeProperties).ToListAsync();
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public async virtual Task<TEntity> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id);
        }

        public async virtual Task<bool> AddAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async virtual Task<bool> UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
        public async virtual Task<bool> RemoveAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}