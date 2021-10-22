using MvcCoreApp.CoreLayer.Dtos.FoodDtos;
using MvcCoreApp.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.CoreLayer.Services
{
    public interface IFoodService : IService<Food,FoodDto>
    {
        Task<IEnumerable<FoodDto>> GetProductsWithCategoryId(int categoryId);
    }
}
