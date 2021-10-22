using MvcCoreApp.CoreLayer.Dtos;
using MvcCoreApp.CoreLayer.Dtos.CategoryDtos;
using MvcCoreApp.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.CoreLayer.Services
{
    public interface ICategoryService:IService<Category,CategoryDto>
    {
        Task<CategoryWithProductDto> GetCategortWithFoodsById(int categoryId);
    }
}
