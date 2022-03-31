using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locacao.Infrastructure.DataAccess.Database
{
    public class BaseRepository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public void Delete(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}