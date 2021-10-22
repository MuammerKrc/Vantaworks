using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MvcCoreApp.ApiClient.Configurations;
using MvcCoreApp.ApiClient.Models;
using MvcCoreApp.ApiClient.Services.Abstracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services
{
    public class PasswordCredentialsTokenService : IPasswordCredentialsTokenService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IClientSettings _clientSettings;

        public PasswordCredentialsTokenService(HttpClient client, IHttpContextAccessor httpContext, IClientSettings clientSettings )
        {
            _client = client;
            _httpContext = httpContext;
            _clientSettings = clientSettings;
        }

        public async Task<TokenResponse> GetAccessTokenByRefreshToken()
        {
            var discovery = await _client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (discovery.IsError)
            {
                throw discovery.Exception;
            }
            var refreshToken = await _httpContext.HttpContext.GetTokenAsync(CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectParameterNames.RefreshToken);

            RefreshTokenRequest refreshTokenRequest = new RefreshTokenRequest()
            {
                Address = discovery.TokenEndpoint,
                RefreshToken = refreshToken,
                ClientSecret = _clientSettings.PasswordCredentials.ClientSecret,
                ClientId = _clientSettings.PasswordCredentials.ClientId
            };
            TokenResponse tokenResponse = await _client.RequestRefreshTokenAsync(refreshTokenRequest);

            if (tokenResponse.IsError)
            {
                throw tokenResponse.Exception;
            }

            AuthenticateResult authenticateResult = await _httpContext.HttpContext.AuthenticateAsync();

            List<AuthenticationToken> authenticationTokens = new List<AuthenticationToken>
            {
                new AuthenticationToken(){Name=OpenIdConnectParameterNames.AccessToken,Value=tokenResponse.AccessToken},
                new AuthenticationToken(){Name=OpenIdConnectParameterNames.RefreshToken,Value=tokenResponse.RefreshToken},
                new AuthenticationToken(){Name=OpenIdConnectParameterNames.ExpiresIn,Value=DateTime.Now.AddSeconds(tokenResponse.ExpiresIn).ToString("O",CultureInfo.InvariantCulture)},
            };
            authenticateResult.Properties.StoreTokens(authenticationTokens);
            await _httpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, authenticateResult.Principal, authenticateResult.Properties);
            return tokenResponse;
        }

        public async Task RevokeRefreshToken()
        {
            var discovery = await _client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (discovery.IsError)
            {
                throw discovery.Exception;
            }
            var refreshToken = await _httpContext.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            TokenRevocationRequest tokenRevocationRequest = new TokenRevocationRequest()
            {
                ClientId = _clientSettings.PasswordCredentials.ClientId,
                ClientSecret = _clientSettings.PasswordCredentials.ClientSecret,
                Address = discovery.RevocationEndpoint,
                Token = refreshToken,
                TokenTypeHint = OpenIdConnectParameterNames.RefreshToken
            };
            await _client.RevokeTokenAsync(tokenRevocationRequest);
        }

        public async Task<Response<bool>> Signin(SigninViewModel signinViewModel)
        {
            var discovery = await _client.GetDiscoveryDocumentAsync("https://localhost:5001");

            if (discovery.IsError)
            {
                throw discovery.Exception;
            }
            PasswordTokenRequest passwordTokenRequest = new PasswordTokenRequest()
            {
                Address = discovery.TokenEndpoint,
                ClientId = _clientSettings.PasswordCredentials.ClientId,
                ClientSecret = _clientSettings.PasswordCredentials.ClientSecret,
                UserName = signinViewModel.Email,
                Password = signinViewModel.Password,
            };
            TokenResponse tokenResponse = await _client.RequestPasswordTokenAsync(passwordTokenRequest);
       
            if(tokenResponse.IsError)
            {
                return Response<bool>.Fail("hatalı giriş", 400);
            }
            UserInfoRequest userInfoRequest = new UserInfoRequest()
            {
                Address = discovery.UserInfoEndpoint,
                Token = tokenResponse.AccessToken
            };
            UserInfoResponse userInfoResponse = await _client.GetUserInfoAsync(userInfoRequest);
            
            if(userInfoResponse.IsError)
            {
                throw userInfoResponse.Exception;
            }
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userInfoResponse.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            List<AuthenticationToken> authenticationTokens = new List<AuthenticationToken>
            {
                new AuthenticationToken(){Name=OpenIdConnectParameterNames.AccessToken,Value=tokenResponse.AccessToken},
                new AuthenticationToken(){Name=OpenIdConnectParameterNames.RefreshToken,Value=tokenResponse.RefreshToken},
                new AuthenticationToken(){Name=OpenIdConnectParameterNames.ExpiresIn,Value=DateTime.Now.AddSeconds(tokenResponse.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)}
            };
            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(authenticationTokens);
            authenticationProperties.IsPersistent = signinViewModel.IsRemember;

            await _httpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            return Response<bool>.Success(true,200);
            }

    }
}
