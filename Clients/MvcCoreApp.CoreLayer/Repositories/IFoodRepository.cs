using MvcCoreApp.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.CoreLayer.Repositories
{
    public interface IFoodRepository:IRepository<Food>
    {
        Task<IEnumerable<Food>> GetProductsWithCategoryId(int categoryId);
    }
}
