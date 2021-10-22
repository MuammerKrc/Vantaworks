using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Client.Models.FoodViewModels
{
    public class FoodCreateViewModel
    {
        [Display(Name ="Adı")]
        [Required(ErrorMessage ="Isim alanı gereklidir!")]
        public string Name { get; set; }
        [Display(Name ="Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı gereklidir!")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name="Fiyatı")]
        [Range(1,(double)decimal.MaxValue,ErrorMessage ="Lütfen istenilen değerler arasında bir fiyat seçiniz")]
        public decimal Price { get; set; }

        [Display(Name = "Ana Sayfada Olsun mu?")]
        public bool IsHome { get; set; }
        [Required(ErrorMessage = "Lütfen bir kategori seçiniz!")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Bir fotoğraf yüklemeniz gerekmetedir")]
        [Display(Name = "Resim")]
        public IFormFile PhotoFile { get; set; }
    }
}
