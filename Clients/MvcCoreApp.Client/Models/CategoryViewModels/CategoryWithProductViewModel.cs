using AutoMapper;
using MvcCoreApp.Client.Models.FoodViewModels;
using MvcCoreApp.CoreLayer.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Client.Models.CategoryViewModels
{
    public class CategoryWithProductViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<FoodViewModel> Foods { get; set; } = new();
    }
}
