using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.Service1.Dtos.CategoryDtos;
using MvcCoreApp.Service1.ServiceAbstracts;
using Shared.ControllerHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Read")]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return QQReturnObject(await _categoryService.GetAllAsync());
        }
        [HttpPost]
        [Authorize(Policy = "allPermission")]
        public async Task<IActionResult>Create(CategoryCreateDto categoryCreate)
        {
            return QQReturnObject(await _categoryService.CreateAsync(categoryCreate));
        }
    }
}
