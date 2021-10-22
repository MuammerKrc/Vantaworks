using MvcCoreApp.ApiClient.Models.CategoryViewModels;
using MvcCoreApp.ApiClient.Models.RecipeViewModels;
using MvcCoreApp.ApiClient.Models.SliderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Models.PagesViewModels
{
    public class HomePageViewModel
    {

        public List<CategoryViewModel> Categories { get; set; }
        public List<SliderViewModel> Sliders { get; set; }
        public List<RecipeViewModel> Recipes { get; set; }
        public string ActiveCategoryId { get; set; }

        public HomePageViewModel()
        {
            Categories = new List<CategoryViewModel>();
            Sliders = new List<SliderViewModel>();
            Recipes = new List<RecipeViewModel>();
        }
    }
}
