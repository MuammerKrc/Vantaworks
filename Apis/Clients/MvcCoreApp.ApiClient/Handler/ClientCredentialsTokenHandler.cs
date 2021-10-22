using MvcCoreApp.ApiClient.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Handler
{
    public class ClientCredentialsTokenHandler:DelegatingHandler
    {
        private readonly IClientCredentialsTokenService _clientCredentialsTokenService;

        public ClientCredentialsTokenHandler(IClientCredentialsTokenService clientCredentialsTokenService)
        {
            _clientCredentialsTokenService = clientCredentialsTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _clientCredentialsTokenService.GetToken());
            var response = await base.SendAsync(request, cancellationToken);
            if(response.StatusCode==System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Unauthorize");
            }
            return response;
        }
    }
}
