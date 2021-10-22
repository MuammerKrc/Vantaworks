using MvcCoreApp.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.CoreLayer.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> GetCategoryWithProduct(int id);
    }
}
