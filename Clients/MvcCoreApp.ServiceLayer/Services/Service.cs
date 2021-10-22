using Microsoft.EntityFrameworkCore;
using MvcCoreApp.CoreLayer.Repositories;
using MvcCoreApp.CoreLayer.Services;
using MvcCoreApp.CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.ServiceLayer.Services
{
    public  class Service<TEntity, TDto> : IService<TEntity, TDto> where TEntity : class, new()
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public  virtual async Task AddAsync(TDto entity)
        {
            await _repository.AddAsync(ObjectMapper.Mapper.Map<TEntity>(entity));
            await _unitOfWork.SaveAsync();
        }
        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            return ObjectMapper.Mapper.Map<List<TDto>>(await _repository.GetAllAsync());
        }

        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return ObjectMapper.Mapper.Map<TDto>(new TEntity());
            }
            return ObjectMapper.Mapper.Map<TDto>(entity);
        }

        public virtual async void Remove(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return;
            }
            _repository.Remove(entity);
            await _unitOfWork.SaveAsync();
        }
        public virtual async Task<TDto> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return ObjectMapper.Mapper.Map<TDto>(await _repository.SingleOrDefaultAsync(predicate));
        }
        public virtual async Task<TDto> Update(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            TEntity updateEntity = _repository.Update(newEntity);
            await _unitOfWork.SaveAsync();
            return ObjectMapper.Mapper.Map<TDto>(updateEntity);
        }

        public virtual async Task<IEnumerable<TDto>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _repository.Where(predicate);
            return ObjectMapper.Mapper.Map<List<TDto>>(await list.ToListAsync());
        }
    }
}
