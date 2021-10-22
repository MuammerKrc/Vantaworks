using MvcCoreApp.CoreLayer.Repositories;
using MvcCoreApp.CoreLayer.UnitOfWorks;
using MvcCoreApp.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.DataLayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext context)
        {
            _appDbContext = context;
        }
        private CategoryRepository categoryRepository;
        private FoodRepository productRepository;
        private SliderRepository sliderRepository;
        public IFoodRepository Food => productRepository = productRepository ?? new FoodRepository(_appDbContext);

        public ICategoryRepository Category => categoryRepository = categoryRepository ?? new CategoryRepository(_appDbContext);

        public ISliderRepository Slider => sliderRepository = sliderRepository ?? new SliderRepository(_appDbContext);

        public void Save()
        {
            _appDbContext.SaveChanges();

        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
