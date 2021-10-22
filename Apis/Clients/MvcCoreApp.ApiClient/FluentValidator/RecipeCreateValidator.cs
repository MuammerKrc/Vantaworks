using FluentValidation;
using MvcCoreApp.ApiClient.Models.RecipeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.FluentValidator
{
    public class RecipeCreateValidator : AbstractValidator<RecipeCreateViewModel>
    {
        public RecipeCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Isim alanı gereklidir!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı gereklidir!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("fiyat alanı boş olamaz").InclusiveBetween(1,int.MaxValue).WithMessage("Fiyat en az 1 ₺ olmalıdır!").ScalePrecision(2, 6).WithMessage("Lütfen istenilen değerler arasında bir değer giriniz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Lütfen bir kategori seçiniz!");
            RuleFor(x => x.PhotoFile).NotEmpty().WithMessage("Bir fotoğraf yüklemeniz gerekmektedir");
        }
    }
}
