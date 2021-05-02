using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bookstore.Services.ShoppingBasket.Extensions;
using Bookstore.Services.ShoppingBasket.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Services.ShoppingBasket.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _client;
        private string _accessToken;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DiscountService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        private async Task<string> GetToken()
        {
            if (!string.IsNullOrWhiteSpace(_accessToken))
            {
                return _accessToken;
            }

            var discoveryDocumentResponse =
                await _client.GetDiscoveryDocumentAsync("https://localhost:5010/");
            if (discoveryDocumentResponse.IsError)
            {
                throw new Exception(discoveryDocumentResponse.Error);
            }

            var customParams = new Parameters(new Dictionary<string, string>
            {
                {"subject_token_type", "urn:ietf:params:oauth:token-type:access_token"},
                {"subject_token", await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")},
                {"scope", "openid profile discount.fullaccess"}
            });

            var tokenResponse = await _client.RequestTokenAsync(new TokenRequest()
            {
                Address = discoveryDocumentResponse.TokenEndpoint,
                GrantType = "urn:ietf:params:oauth:grant-type:token_exchange",
                Parameters = customParams,
                ClientId = "shoppingbaskettodownstreamtokenexchangeclient",
                ClientSecret = "0cdea0bc-779e-4368-b46b-09956f70712c"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }

            _accessToken = tokenResponse.AccessToken;
            return _accessToken;
        }

        public async Task<Coupon> GetCoupon(Guid userId)
        {
            _client.SetBearerToken(await GetToken());
            var response = await _client.GetAsync($"/api/discount/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.ReadContentAs<Coupon>();
        }

        public async Task<Coupon> GetCouponWithError(Guid couponId)
        {
            var response = await _client.GetAsync($"/api/discount/error/{couponId}");
            return await response.ReadContentAs<Coupon>();
        }
    }
}
