using MvcCoreApp.Service1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.SeedData
{
    public class SliderSeedData
    {
        public List<Slider> Sliders { get; set; }

        public SliderSeedData()
        {
            Sliders = new List<Slider>()
            {
                new Slider(){ImageUrl="slider/s1.png",Description="En güzel burgerlar burada",Title="Burgerlar"},
                new Slider(){ImageUrl="slider/s2.png",Description="En güzel pizzalar burada",Title="Pizzalar"},
                new Slider(){ImageUrl="slider/s3.png",Description="En güzel noddlelar burada",Title="Noddle"}
            };
        }
    }
}
