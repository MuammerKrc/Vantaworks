using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MvcCoreApp.ApiClient.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Handler
{
    public class PasswordCredentialsTokenHandler:DelegatingHandler
    {
        private readonly IPasswordCredentialsTokenService _passwordCredentialsTokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PasswordCredentialsTokenHandler(IPasswordCredentialsTokenService passwordCredentialsTokenService, IHttpContextAccessor httpContextAccessor)
        {
            _passwordCredentialsTokenService = passwordCredentialsTokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await base.SendAsync(request, cancellationToken);
            if(response.StatusCode==System.Net.HttpStatusCode.Unauthorized)
            {
                TokenResponse tokenResponse = await _passwordCredentialsTokenService.GetAccessTokenByRefreshToken();
                if(tokenResponse!=null)
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }
            if(response.StatusCode==System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Giriş Sağlanamadı");
            }
            return response;
        }
    }
}
