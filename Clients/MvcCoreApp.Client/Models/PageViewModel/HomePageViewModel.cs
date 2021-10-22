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

namespace MvcCoreApp.Client.Models.PageViewModel
{
    public class HomePageViewModel
    {
        private readonly IMapper _mapper;
        public HomePageViewModel(List<CategoryDto> categoryDto,List<FoodDto> foodDto,List<SliderDto> sliderDtos,int activeCategoryId,IMapper mapper)
        {
            _mapper = mapper;
            Categories = _mapper.Map<List<CategoryViewModel>>(categoryDto);
            Foods = _mapper.Map<List<FoodViewModel>>(foodDto);
            Slider = _mapper.Map<List<SliderViewModel>>(sliderDtos);
            ActiveCategoryId = activeCategoryId;
        }
        public List<FoodViewModel> Foods { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public List<SliderViewModel> Slider { get; set; }
        public int ActiveCategoryId { get; set; }
    }
}
