using MvcCoreApp.ApiClient.Models.CategoryViewModels;
using MvcCoreApp.ApiClient.Models.PagesViewModels;
using MvcCoreApp.ApiClient.Models.RecipeViewModels;
using MvcCoreApp.ApiClient.Models.SliderViewModels;
using MvcCoreApp.ApiClient.Services.Abstracts.MicroservicesAbstract;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services.Microservices
{
    public class ServiceOneWithClientCredentialsService : IServiceOneWithClientCredentialsService
    {
        private readonly HttpClient _client;

        public ServiceOneWithClientCredentialsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var response = await _client.GetAsync("Categories");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var data = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();
            return data.Data;
        }

        public async Task<List<SliderViewModel>> GetAllSliders()
        {
            var response = await _client.GetAsync("Sliders");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var data = await response.Content.ReadFromJsonAsync<Response<List<SliderViewModel>>>();
            return data.Data;
        }

        public async Task<HomePageViewModel> GetHomePageViewModel(string activeCategoryId)
        {
            var categories = await GetAllCategories();
            if(String.IsNullOrEmpty(activeCategoryId))
            {
                activeCategoryId = categories.FirstOrDefault().Id;
            }
            var recipe = await GetRecipesWithCategoryId(activeCategoryId);
            var slider = await GetAllSliders();
            return new HomePageViewModel() { Categories = categories, Recipes = recipe, Sliders = slider, ActiveCategoryId = activeCategoryId };
        }


        public async Task<List<RecipeViewModel>> GetRecipesWithCategoryId(string categoryId)
        {
            var response = await _client.GetAsync($"Foods/{categoryId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var data = await response.Content.ReadFromJsonAsync<Response<List<RecipeViewModel>>>();
            return data.Data;
        }
    }
}
