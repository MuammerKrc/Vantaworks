using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.Service1.Dtos.FoodDtos;
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
    public class FoodsController : CustomBaseController
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("{categoryId}")]
        [Authorize(Policy = "Read")]
        public async Task<IActionResult> GetAllByCategoryId(string categoryId)
        {
            return QQReturnObject(await (_foodService.GetProductWithCategoryId(categoryId)));
        }
        [HttpPost]
        [Authorize(Policy = "AllPermission")]
        public async Task<IActionResult> Create(FoodCreateDto foodCreateDto)
        {
            return QQReturnObject(await (_foodService.CreateAsync(foodCreateDto)));
        }
    }
}
