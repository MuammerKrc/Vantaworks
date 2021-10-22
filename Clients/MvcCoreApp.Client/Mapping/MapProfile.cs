using AutoMapper;
using MvcCoreApp.Client.Models.CategoryViewModels;
using MvcCoreApp.Client.Models.FoodViewModels;
using MvcCoreApp.Client.Models.SliderViewModels;
using MvcCoreApp.CoreLayer.Dtos.CategoryDtos;
using MvcCoreApp.CoreLayer.Dtos.FoodDtos;
using MvcCoreApp.CoreLayer.Dtos.SliderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Client.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            //category
            CreateMap<CategoryViewModel, CategoryDto>().ReverseMap();
            CreateMap<CategoryWithProductDto, CategoryWithProductViewModel>().ReverseMap();
            //food
            CreateMap<FoodViewModel, FoodDto>().ReverseMap();
            CreateMap<FoodWithCategoryDto, FoodWithCategoryDto>().ReverseMap();
            CreateMap<FoodCreateViewModel, FoodDto>().ReverseMap();
            //Slider
            CreateMap<SliderViewModel, SliderDto>().ReverseMap();
        }
    }
}
