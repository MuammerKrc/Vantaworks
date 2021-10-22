using MvcCoreApp.ApiClient.Models;
using MvcCoreApp.ApiClient.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services
{
    public class UserService : IUserService
    {
        public Task<UserViewModel> GetUser()
        {
            throw new NotImplementedException();
        }
    }
}
