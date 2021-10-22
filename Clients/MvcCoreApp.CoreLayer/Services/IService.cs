using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.CoreLayer.Services
{
    public interface IService<TEntity,TDto>
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<IEnumerable<TDto>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TDto> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TDto entity);
        void Remove(int id);
        Task<TDto> Update(TDto entity);
    }
}
