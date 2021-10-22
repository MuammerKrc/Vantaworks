using MvcCoreApp.Service1.Dtos.CategoryDtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.ServiceAbstracts
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<NoContent>> CreateAsync(CategoryCreateDto categoryCreateDto);
    }
}
