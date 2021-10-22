using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Models.RecipeViewModels
{
    public class RecipeCreateViewModel
    {
        [Display(Name="Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name ="Adı")]
        public string Name { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Kategori")]
        public string CategoryId { get; set; }
        [Display(Name = "Ana Sayfada Olsun mu?")]
        public bool IsHome { get; set; }
        [Display(Name = "Resim")]
        public IFormFile PhotoFile { get; set; }

    }
}
