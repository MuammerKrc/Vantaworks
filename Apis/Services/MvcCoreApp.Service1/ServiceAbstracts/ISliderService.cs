using MvcCoreApp.Service1.Dtos.SliderDtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.ServiceAbstracts
{
    public interface ISliderService
    {
        Task<Response<List<SliderDto>>> GetAllAsync();
    }
}
