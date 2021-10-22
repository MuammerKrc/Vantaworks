using MvcCoreApp.ApiClient.Models.CategoryViewModels;
using MvcCoreApp.ApiClient.Models.RecipeViewModels;
using MvcCoreApp.ApiClient.Services.Abstracts.MicroservicesAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services.Microservices
{
    public class ServiceOneWithPasswordCredentialsService : IServiceOneWithPasswordCredentialsService
    {
        private readonly HttpClient _client;

        public ServiceOneWithPasswordCredentialsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> CreateCategory(CategoryCreateViewModel categoryCreateViewModel)
        {
            var response = await _client.PostAsJsonAsync<CategoryCreateViewModel>("categories", categoryCreateViewModel);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateRecipe(RecipeCreateViewModel recipeCreateViewModel)
        {
            var response = await _client.PostAsJsonAsync<RecipeCreateViewModel>("Foods", recipeCreateViewModel);
            return response.IsSuccessStatusCode;
        }
    }
}
