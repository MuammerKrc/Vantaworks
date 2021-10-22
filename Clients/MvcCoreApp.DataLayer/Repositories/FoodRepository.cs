using Microsoft.EntityFrameworkCore;
using MvcCoreApp.CoreLayer.Models;
using MvcCoreApp.CoreLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.DataLayer.Repositories
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        public FoodRepository(AppDbContext context) : base(context)
        {

        }
        private AppDbContext context { get => _context as AppDbContext; }

        private DbSet<Food> _products { get => context.Products; }

        public async Task<IEnumerable<Food>> GetProductsWithCategoryId(int categoryId)
        {
            return await Where(i => i.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Food> GetProductWithCategory(int id)
        {
            return await _products.Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
