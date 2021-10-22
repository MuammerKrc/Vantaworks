using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Service1.Dtos.FoodDtos
{
    public class FoodCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
        public bool IsHome { get; set; }
    }
}
