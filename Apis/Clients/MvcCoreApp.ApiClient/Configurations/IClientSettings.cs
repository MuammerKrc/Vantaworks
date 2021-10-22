using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.ApiClient.Configurations
{
    public interface IClientSettings
    {
        public Client ClientCredentials { get; set; }
        public Client PasswordCredentials { get; set; }
    }
}
