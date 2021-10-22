using MvcCoreApp.CoreLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.CoreLayer.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ISliderRepository Slider { get; }
        IFoodRepository Food { get; }
        ICategoryRepository Category { get; }
        Task SaveAsync();
        void Save();
    }
}
