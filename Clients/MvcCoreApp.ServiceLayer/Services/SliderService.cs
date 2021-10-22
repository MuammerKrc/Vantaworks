using MvcCoreApp.CoreLayer.Dtos.SliderDtos;
using MvcCoreApp.CoreLayer.Models;
using MvcCoreApp.CoreLayer.Repositories;
using MvcCoreApp.CoreLayer.Services;
using MvcCoreApp.CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.ServiceLayer.Services
{
    public class SliderService : Service<Slider, SliderDto>, ISliderService
    {
        public SliderService(IUnitOfWork unitOfWork, IRepository<Slider> repository) : 
            base(unitOfWork, repository)
        {

        }
    }
}
