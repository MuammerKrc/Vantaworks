using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Configurations
{
    public class ClientSettings:IClientSettings
    {
        public Client ClientCredentials { get; set; }
        public Client PasswordCredentials { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
