// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Net5.AspNet.Workshop.Infrastructure.Constants;
using System.Collections.Generic;
using System.Security.Claims;

namespace Net5.AspNet.Workshop.IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Email(),
                        new IdentityResources.Profile(),
                        new IdentityResource
                        {
                            Name="Net5.AspNet.Workshop",
                            DisplayName = "Net5.AspNet.Workshop OIC Profile",
                            Description = "Your Net5 Asp.Net OIC profile information (fullname, role, permission)",
                            Emphasize=true,
                            UserClaims = {SecurityClaimType.GrantAccess,ClaimTypes.Role,JwtClaimTypes.Role,JwtClaimTypes.Name}
                        }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Net5.AspNet.Workshop.IdentityProvider.Api"),
                new ApiScope("Net5.AspNet.Workshop.Location.Api"),
                new ApiScope("Net5.AspNet.Workshop.Workshop.Api")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource
                {
                    Name = "Net5.AspNet.Workshop.IdentityProvider.Api",
                    DisplayName = "Net5.AspNet.Workshop OIC Identity Provider API",
                    Scopes = {"Net5.AspNet.Workshop.IdentityProvider.Api" },
                    UserClaims = { SecurityClaimType.GrantAccess, ClaimTypes.Role, JwtClaimTypes.Role, JwtClaimTypes.Name },
                    ApiSecrets = { new Secret { Value = "o90IbCACXKUkunXoa18cODcLKnQTbjOo5ihEw9j58+8=" } }
                },
                new ApiResource
                {
                    Name = "Net5.AspNet.Workshop.Location.Api",
                    DisplayName = "Net5.AspNet.Workshop OIC Location API",
                    Scopes = {"Net5.AspNet.Workshop.Location.Api" },
                    UserClaims = { SecurityClaimType.GrantAccess, ClaimTypes.Role, JwtClaimTypes.Role, JwtClaimTypes.Name },
                    ApiSecrets = { new Secret { Value = "o90IbCACXKUkunXoa18cODcLKnQTbjOo5ihEw9j58+8=" } }
                },
                 new ApiResource
                {
                    Name="Net5.AspNet.Workshop.Workshop.Api",
                    DisplayName = "Net5.AspNet OIC Workshop API",
                    Scopes = { "Net5.AspNet.Workshop.Workshop.Api" },
                    UserClaims = { SecurityClaimType.GrantAccess,ClaimTypes.Role, JwtClaimTypes.Role, JwtClaimTypes.Name },
                    ApiSecrets = { new Secret{Value = "o90IbCACXKUkunXoa18cODcLKnQTbjOo5ihEw9j58+8=" } }
                },
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {                
                new Client
                {
                    ClientId = "Net5.AspNet.Workshop.Client",
                    ClientName = "Net5.AspNet.Workshop.Client",
                    ClientSecrets = { new Secret { Value= "o90IbCACXKUkunXoa18cODcLKnQTbjOo5ihEw9j58+8=" } },
                    AllowedGrantTypes = { GrantType.ResourceOwnerPassword,GrantType.ClientCredentials},
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 86400,
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    Enabled = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "Net5.AspNet.Workshop",
                        "Net5.AspNet.Workshop.IdentityProvider.Api",
                        "Net5.AspNet.Workshop.Location.Api",
                        "Net5.AspNet.Workshop.Workshop.Api"
                    },
                    AllowedCorsOrigins = { "http://localhost:4200" }
                }
            };
    }
}