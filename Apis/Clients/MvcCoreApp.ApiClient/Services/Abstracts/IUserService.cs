using MvcCoreApp.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services.Abstracts
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
