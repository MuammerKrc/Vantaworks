using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCoreApp.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.DataLayer.SeedData
{
    public class SliderSeed : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasData(new List<Slider>()
            {
                new Slider(){Id=1,ImageUrl="slider/s1.png",Description="En güzel burgerlar burada",Title="Burgerlar"},
                new Slider(){Id=2,ImageUrl="slider/s2.png",Description="En güzel pizzalar burada",Title="Pizzalar"},
                new Slider(){Id=3,ImageUrl="slider/s3.png",Description="En güzel noddlelar burada",Title="Noddle"}
            });
        }
    }
}
