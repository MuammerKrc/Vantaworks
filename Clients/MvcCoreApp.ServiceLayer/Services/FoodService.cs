using MvcCoreApp.CoreLayer.Dtos.FoodDtos;
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
    public class FoodService : Service<Food, FoodDto>,IFoodService
    {
        public FoodService(IUnitOfWork unitOfWork, IRepository<Food> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<FoodDto>> GetProductsWithCategoryId(int categoryId)
        {
            var result = await _unitOfWork.Food.GetProductsWithCategoryId(categoryId);
            if(result==null)
            {
                return new List<FoodDto>();
            }
            return ObjectMapper.Mapper.Map<List<FoodDto>>(result);
        }

        public async Task<FoodWithCategoryDto> GetWithCategoryByIdAsync(int Id)
        {
            var result = await _unitOfWork.Category.GetCategoryWithProduct(Id);
            if (result == null)
            {
                return new FoodWithCategoryDto();
            }
            return ObjectMapper.Mapper.Map<FoodWithCategoryDto>(result);
        }
    }
}
