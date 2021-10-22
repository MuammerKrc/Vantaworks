using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MvcCoreApp.ApiClient.Models;
using MvcCoreApp.ApiClient.Models.CategoryViewModels;
using MvcCoreApp.ApiClient.Models.RecipeViewModels;
using MvcCoreApp.ApiClient.Services.Abstracts.MicroservicesAbstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceOneWithClientCredentialsService _serviceOneClientService;
        private readonly IServiceOneWithPasswordCredentialsService _serviceOnePasswordService;

        public HomeController(ILogger<HomeController> logger, IServiceOneWithClientCredentialsService serviceOneClientService, IServiceOneWithPasswordCredentialsService serviceOnePasswordService)
        {
            _logger = logger;
            _serviceOneClientService = serviceOneClientService;
            _serviceOnePasswordService = serviceOnePasswordService;
        }

        public async Task<IActionResult> Index(string? activeCategory)
        {
            try
            {
                var result = await _serviceOneClientService.GetHomePageViewModel(activeCategory);
                return View(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreateRecipe()
        {
            try
            {
                var categories = await _serviceOneClientService.GetAllCategories();
                ViewBag.categorylist = new SelectList(categories, "Id", "Name", categories.FirstOrDefault());
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRecipe(RecipeCreateViewModel recipeCreateViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var categories = await _serviceOneClientService.GetAllCategories();
                    ViewBag.categorylist = new SelectList(categories, "Id", "Name", categories.FirstOrDefault());
                    return View(recipeCreateViewModel);
                }
                if (!(recipeCreateViewModel.PhotoFile != null && recipeCreateViewModel.PhotoFile.Length > 0))
                {
                    var categories = await _serviceOneClientService.GetAllCategories();
                    ViewBag.categorylist = new SelectList(categories, "Id", "Name", categories.FirstOrDefault());
                    ModelState.AddModelError("", "lütfen bir fotoğraf ekleyiniz");
                    return View(recipeCreateViewModel);
                }
                recipeCreateViewModel.ImageUrl = await AddPhoto(recipeCreateViewModel.PhotoFile);

                await _serviceOnePasswordService.CreateRecipe(recipeCreateViewModel);
                return RedirectToAction("Index", "Home");
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
        public async Task<string> AddPhoto(IFormFile PhotoFile)
        {
            var flag = true;
            var path = "";
            int nth = 1;
            while (flag)
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/menu", nth.ToString() +PhotoFile.FileName);
                if (!System.IO.File.Exists(path))
                {
                    flag = false;
                    break;
                }
                nth++;
            }
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await PhotoFile.CopyToAsync(stream);
                var returnPath = PhotoFile.FileName;
                var savePath = Path.Combine("menu", returnPath);
                return savePath;
            }
        }
    }
}
