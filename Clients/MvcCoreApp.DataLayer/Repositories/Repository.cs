using Microsoft.EntityFrameworkCore;
using MvcCoreApp.CoreLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.DataLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entity;
        public Repository(AppDbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _entity.AddRangeAsync(entities);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);

        }

        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entity.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entity.Where(predicate).SingleOrDefaultAsync();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
