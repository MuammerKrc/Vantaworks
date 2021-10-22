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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
        private AppDbContext context { get => _context as AppDbContext; }
        private DbSet<Category> _categories { get => context.Set<Category>(); }
        public async Task<Category> GetCategoryWithProduct(int id)
        {
            return await _categories.Include(i => i.Foods).FirstOrDefaultAsync(i => i.Id == id);
        }
        
    }
}
