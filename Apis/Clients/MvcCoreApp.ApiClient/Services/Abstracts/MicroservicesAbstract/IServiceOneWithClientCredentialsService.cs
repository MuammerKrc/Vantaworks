using MvcCoreApp.ApiClient.Models;
using MvcCoreApp.ApiClient.Models.CategoryViewModels;
using MvcCoreApp.ApiClient.Models.PagesViewModels;
using MvcCoreApp.ApiClient.Models.RecipeViewModels;
using MvcCoreApp.ApiClient.Models.SliderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services.Abstracts.MicroservicesAbstract
{
    public interface IServiceOneWithClientCredentialsService
    {
        Task<HomePageViewModel> GetHomePageViewModel(string activeCategoryId);
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<SliderViewModel>> GetAllSliders();
        Task<List<RecipeViewModel>> GetRecipesWithCategoryId(string categoryId);
    }
}
