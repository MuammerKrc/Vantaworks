using MvcCoreApp.ApiClient.Models.CategoryViewModels;
using MvcCoreApp.ApiClient.Models.RecipeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services.Abstracts.MicroservicesAbstract
{
    public interface IServiceOneWithPasswordCredentialsService
    {
        Task<bool> CreateCategory(CategoryCreateViewModel categoryCreateViewModel);
        Task<bool> CreateRecipe(RecipeCreateViewModel recipeCreateViewModel);
    }
}
