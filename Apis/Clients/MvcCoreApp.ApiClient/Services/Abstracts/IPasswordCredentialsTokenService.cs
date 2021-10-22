using IdentityModel.Client;
using MvcCoreApp.ApiClient.Models;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services.Abstracts
{
    public interface IPasswordCredentialsTokenService
    {
        Task<Response<bool>> Signin(SigninViewModel registerViewModel);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
