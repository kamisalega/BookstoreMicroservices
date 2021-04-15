// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Bookstore.Services.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("bookstore", "Bookstore APIs")
            {
                Scopes = {"bookstore.fullaccess"}
            }
        };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("bookcatalog.fullaccess"),
                new ApiScope("shoppingbasket.fullaccess")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientName = "Bookstore Machine 2 Machine Client",
                    ClientId = "bookstorem2m",
                    ClientSecrets = {new Secret("eac7008f-1b35-4325-ac8d-4a71932e6088".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"bookcatalog.fullaccess"}
                },
                new Client()
                {
                    ClientName = "Bookstore Interactive Client",
                    ClientId = "bookstoreinteractive",
                    ClientSecrets = {new Secret("ce766e16-df99-411d-8d31-0f5bbc6b8eba".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:5000/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:5000/signin-oidc"},
                    AllowedScopes = {"openid", "profile", "shoppingbasket.fullaccess"}
                },
                new Client()
                {
                    ClientName = "Bookstore Client",
                    ClientId = "bookstore",
                    ClientSecrets = {new Secret("ce766e16-df99-411d-8d31-0f5bbc6b8eba".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:5000/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:5000/signin-oidc"},
                    AllowedScopes = {"openid", "profile", "shoppingbasket.fullaccess"}
                }
            };
    }
}
