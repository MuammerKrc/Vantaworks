using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.Service1.ServiceAbstracts;
using Shared.ControllerHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : CustomBaseController
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return QQReturnObject(await _sliderService.GetAllAsync());
        }
    }
}
