using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using MvcCoreApp.ApiClient.Configurations;
using MvcCoreApp.ApiClient.Models;
using MvcCoreApp.ApiClient.Services.Abstracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Services
{
    public class ClientCredentialsTokenService : IClientCredentialsTokenService
    {
        private readonly IClientSettings _clientSettings;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private readonly HttpClient _client;

        public ClientCredentialsTokenService( IClientSettings clientSettings, IClientAccessTokenCache clientAccessTokenCache, HttpClient client)
        {
            _clientSettings = clientSettings;
            _clientAccessTokenCache = clientAccessTokenCache;
            _client = client;
        }

        public async Task<string> GetToken()
        {
            ClientAccessToken clientAccessToken = await _clientAccessTokenCache.GetAsync("vantaworksClient");
            if(clientAccessToken!=null)
            {
                return clientAccessToken.AccessToken;
            }
            var disco = await _client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if(disco.IsError)
            {
                throw disco.Exception;
            }
            ClientCredentialsTokenRequest clientCredentials = new ClientCredentialsTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = _clientSettings.ClientCredentials.ClientId,
                ClientSecret = _clientSettings.ClientCredentials.ClientSecret
            };
            TokenResponse tokenResponse = await _client.RequestClientCredentialsTokenAsync(clientCredentials);

            if(tokenResponse.IsError)
            {
                throw tokenResponse.Exception;
            }

            await _clientAccessTokenCache.SetAsync("vantaworksClient", tokenResponse.AccessToken, tokenResponse.ExpiresIn);
            return tokenResponse.AccessToken;
        }
    }
}
