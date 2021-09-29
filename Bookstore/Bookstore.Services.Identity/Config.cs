// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServerHost.Quickstart.UI.Resource;

namespace Bookstore.Services.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Address(),
                new CreditCard()
                
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
                new ApiScope("bookstore.fullaccess")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientName = "Bookstore Machine 2 Machine Client",
                    ClientId = "bookstorem2m",
                    ClientSecrets = { new Secret("eac7008f-1b35-4325-ac8d-4a71932e6088".Sha256())},
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris =           { "https://localhost:5000/" },
                    PostLogoutRedirectUris = { "https://localhost:5000/" },
                    AllowedCorsOrigins =     { "https://localhost:5000" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "credit_card",
                        "bookstore.fullaccess"
                    }
                }
            };
    }
}
