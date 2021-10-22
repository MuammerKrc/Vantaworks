using MvcCoreApp.CoreLayer.Dtos.FoodDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApp.CoreLayer.Dtos.CategoryDtos
{
    public class CategoryWithProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<FoodDto> Foods { get; set; } = new();
    }
}
