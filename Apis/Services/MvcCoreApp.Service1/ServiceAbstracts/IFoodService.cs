using MvcCoreApp.Service1.Dtos.FoodDtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.ServiceAbstracts
{
    public interface IFoodService
    {
        Task<Response<List<FoodDto>>> GetProductWithCategoryId(string categoryId);
        Task<Response<FoodDto>> CreateAsync(FoodCreateDto foodDto);
    }
}
