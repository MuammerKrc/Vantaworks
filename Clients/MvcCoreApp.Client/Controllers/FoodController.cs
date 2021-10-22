using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCoreApp.Client.Models.FoodViewModels;
using MvcCoreApp.CoreLayer.Dtos.FoodDtos;
using MvcCoreApp.CoreLayer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Client.Controllers
{
    public class FoodController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IFoodService _foodService;
        private readonly IMapper _mapper;

        public FoodController(IMapper mapper,ICategoryService categoryService, IFoodService foodService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                ViewBag.categoryList = new SelectList(categories, "Id", "Name", categories.FirstOrDefault());
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(FoodCreateViewModel foodViewModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    var categories = await _categoryService.GetAllAsync();
                    ViewBag.categorylist = new SelectList(categories, "Id", "Name",categories.FirstOrDefault());
                    return View(foodViewModel);
                }
                if (!(foodViewModel.PhotoFile != null && foodViewModel.PhotoFile.Length > 0))
                {
                    var categories = await _categoryService.GetAllAsync();
                    ViewBag.categorylist = new SelectList(categories, "Id", "Name", categories.FirstOrDefault());
                    ModelState.AddModelError("", "lütfen bir fotoğraf ekleyiniz");
                    return View(foodViewModel);
                }
                var flag = true;
                var path = "";
                int nth = 1;
                while (flag)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/menu", nth.ToString() + foodViewModel.PhotoFile.FileName);
                    if (!System.IO.File.Exists(path))
                    {
                        flag = false;
                        break;
                    }
                    nth++;
                }
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await foodViewModel.PhotoFile.CopyToAsync(stream);
                    var returnPath = foodViewModel.PhotoFile.FileName;
                    var savePath = Path.Combine("menu", returnPath);
                    foodViewModel.ImageUrl = savePath;
                    await _foodService.AddAsync(_mapper.Map<FoodDto>(foodViewModel));
                    RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
