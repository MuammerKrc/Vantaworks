using AutoMapper;
using MvcCoreApp.CoreLayer.Dtos;
using MvcCoreApp.CoreLayer.Dtos.CategoryDtos;
using MvcCoreApp.CoreLayer.Dtos.FoodDtos;
using MvcCoreApp.CoreLayer.Dtos.SliderDtos;
using MvcCoreApp.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace MvcCoreApp.ServiceLayer
{
    internal class DtoMapper : Profile
    {
        public DtoMapper()
        {
            //food
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<Food, FoodWithCategoryDto>().ReverseMap();
            //category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductDto>().ReverseMap();
            //Slider
            CreateMap<Slider, SliderDto>().ReverseMap();
        }
    }
}
