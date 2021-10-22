using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCoreApp.CoreLayer.Repositories;
using MvcCoreApp.CoreLayer.Services;
using MvcCoreApp.CoreLayer.UnitOfWorks;
using MvcCoreApp.DataLayer.Repositories;
using MvcCoreApp.DataLayer.UnitOfWorks;
using MvcCoreApp.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.ServiceLayer.ServiceConfigurations
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IService<,>), typeof(Service<,>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
