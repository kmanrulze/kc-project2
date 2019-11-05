using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dbnd.Api
{
    public class Auth0Requester
    {
        IHttpClientFactory _clientFactory;
        public Auth0Requester(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<UserProfile> GetUserProfile(string bearerString)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://dbnd.auth0.com/userinfo");
            request.Headers.Add("Authorization", bearerString);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = client.SendAsync(request).Result;

            return JsonConvert.DeserializeObject<UserProfile>(await response.Content.ReadAsStringAsync());
        }
    }
}
