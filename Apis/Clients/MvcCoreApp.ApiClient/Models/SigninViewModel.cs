using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Models
{
    public class SigninViewModel
    {
        [Display(Name = "Email adresiniz")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Şifreniz ")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        [Required]

        public bool IsRemember { get; set; }
    }
}
