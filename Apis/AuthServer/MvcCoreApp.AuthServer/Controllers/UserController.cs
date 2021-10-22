using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.AuthServer.Dtos;
using MvcCoreApp.AuthServer.Models;
using Shared.ControllerHelper;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MvcCoreApp.AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class UserController : CustomBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var ıd = HttpContext.User.Claims.FirstOrDefault(i => i.Type == JwtRegisteredClaimNames.Sub).Value;
            if(ıd==null)
            {
                return QQReturnObject(Response<NoContent>.Fail("Bad Request", 400));
            }
            var user = await _userManager.FindByIdAsync(ıd);
            if(user==null)
            {
                return QQReturnObject(Response<NoContent>.Fail("Bad Request", 400));
            }
            return QQReturnObject(Response<UserDto>.Success(new UserDto() 
            {
                Email = user.Email, 
                UserName = user.UserName, 
                Id = user.Id 
            }, 200)); 
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserCreateDto userCreateDto)
        {
            if(ModelState.IsValid)
            {
                var existUser = await _userManager.FindByNameAsync(userCreateDto.UserName);
                if(existUser!=null)
                {
                    return QQReturnObject(Response<NoContent>.Fail("Bu Kullanıcı Adı Kayıtlıdır", 400));
                }

                var user = new ApplicationUser()
                {
                    UserName = userCreateDto.UserName,
                    Email = userCreateDto.Email
                };
                var result = await _userManager.CreateAsync(user, userCreateDto.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(Response<NoContent>.Fail(result.Errors.Select(i => i.Description).ToList(), 400));
                }
                return QQReturnObject(Response<NoContent>.Success(201));
            }
            return QQReturnObject(Response<NoContent>.Fail("Bad Request", 400));
        }
    }
}
