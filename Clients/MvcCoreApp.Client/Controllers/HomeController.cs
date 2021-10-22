using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCoreApp.Client.Models;
using MvcCoreApp.Client.Models.PageViewModel;
using MvcCoreApp.CoreLayer.Models;
using MvcCoreApp.CoreLayer.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFoodService _productService;
        private readonly ISliderService _sliderService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IFoodService productService, ISliderService sliderService, ICategoryService categoryService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _sliderService = sliderService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int activeCategoryId)
        {
            try
            {
                var categoryDto = await _categoryService.GetAllAsync();
                if(activeCategoryId==0)
                {
                    activeCategoryId = categoryDto.FirstOrDefault().Id;
                }
                var foodDto = await _productService.GetProductsWithCategoryId(activeCategoryId);
                var slidersDto = await _sliderService.GetAllAsync();
                return View(new HomePageViewModel(categoryDto.ToList(), foodDto.ToList(), slidersDto.ToList(), activeCategoryId,_mapper));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult CreateFood()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateFood(IFormFile photo,Food product)
        {
            try
            {
                if (photo != null && photo.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await photo.CopyToAsync(stream);
                    var returnPath = photo.FileName;
                }
                return View();
            }
            catch
            {
                throw;
            }
        }


        public async Task<IActionResult> FoodDetail(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                return View(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
