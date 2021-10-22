// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MvcCoreApp.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resource_service1"){Scopes=new[]{"service1_read","service1_fullpermission" }},
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("service1_read","clien1 için yazma izni"),
                new ApiScope("service1_fullpermission","client1 için okuma izni"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientName="Service1ToRead",
                    ClientId="Service1ToRead",
                    ClientSecrets=new[]{new Secret("alsfklaavas".Sha256()) },
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes=
                    {
                        "service1_read",
                        IdentityServerConstants.LocalApi.ScopeName
                    },
                    AccessTokenLifetime=3*60*60,
                   
                },
                new Client()
                {
                    ClientName="Service1ToAll",
                    ClientId="Service1ToAll",
                    ClientSecrets=new[]{new Secret("ascasaaqf1232axc".Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes=
                    {
                        "service1_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName
                    },
                    AccessTokenLifetime=2*60*60,
                    AllowOfflineAccess=true,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    RefreshTokenUsage=TokenUsage.ReUse,
                    AbsoluteRefreshTokenLifetime=60*60*60
                }
            };
        }
    }
}