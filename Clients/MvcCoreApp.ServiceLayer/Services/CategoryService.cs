using MvcCoreApp.CoreLayer.Dtos;
using MvcCoreApp.CoreLayer.Dtos.CategoryDtos;
using MvcCoreApp.CoreLayer.Models;
using MvcCoreApp.CoreLayer.Repositories;
using MvcCoreApp.CoreLayer.Services;
using MvcCoreApp.CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.ServiceLayer.Services
{
    public class CategoryService : Service<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<CategoryWithProductDto> GetCategortWithFoodsById(int categoryId)
        {
            var result = await _unitOfWork.Category.GetCategoryWithProduct(categoryId);

            if(result == null)
            {
                return new CategoryWithProductDto();
            }
            return ObjectMapper.Mapper.Map<CategoryWithProductDto>(result);
        }
    }
}
