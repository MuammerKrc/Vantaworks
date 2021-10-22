using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.ApiClient.Models;
using MvcCoreApp.ApiClient.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IPasswordCredentialsTokenService _passwordTokenService;

        public AuthenticationController(IPasswordCredentialsTokenService passwordTokenService)
        {
            _passwordTokenService = passwordTokenService;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SigninViewModel signinViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(signinViewModel);
            }
            var result = await _passwordTokenService.Signin(signinViewModel);
            if (!result.IsSuccess)
            {
                if (result.Errors.Any())
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x));
                }
            }
            return result.IsSuccess ? RedirectToAction("Index", "Home") : View(signinViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            await _passwordTokenService.RevokeRefreshToken();
            return RedirectToAction("Index", "Home");
        }
    }
}
