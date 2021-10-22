using AutoMapper;
using MvcCoreApp.Service1.Dtos.CategoryDtos;
using MvcCoreApp.Service1.Dtos.FoodDtos;
using MvcCoreApp.Service1.Dtos.SliderDtos;
using MvcCoreApp.Service1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.Mapping
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            //category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            //Food
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<Food, FoodCreateDto>().ReverseMap();
            //Slider
            CreateMap<Slider, SliderDto>().ReverseMap();
        }
    }
}
