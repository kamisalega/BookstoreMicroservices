using System.Collections.Generic;
using System.Linq;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;


namespace IdentityServerHost.Quickstart.UI.Resource
{
    public class CreditCard : IdentityResource
    {
        public CreditCard()
        {
            Name = "credit_card";
            DisplayName = "Your postal address";
            Emphasize = true;
            UserClaims = ScopeToClaimsMapping["credit_card"].ToList();
        }

        public readonly Dictionary<string, IEnumerable<string>> ScopeToClaimsMapping =
            new Dictionary<string, IEnumerable<string>>
            {
                {
                    "credit_card", new[]
                    {
                        "credit_card"
                    }
                }
            };
    }
}