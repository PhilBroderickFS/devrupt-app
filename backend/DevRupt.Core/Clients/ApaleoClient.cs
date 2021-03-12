using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevRupt.Core.Configuration;
using DevRupt.Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DevRupt.Core.Clients
{
    public class ApaleoClient : IApaleoClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<ApaleoClientCredentials> _options;

        public ApaleoClient(IHttpClientFactory httpClientFactory, IOptions<ApaleoClientCredentials> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options;
        }

        public async Task<AuthenticatedClientDto> AuthenticateClient()
        {
            try
            {
                var body = "grant_type=client_credentials";
                var encodedCredentials =
                    Convert.ToBase64String(
                        Encoding.UTF8.GetBytes($"{_options.Value.ClientId}:{_options.Value.ClientSecret}"));

                using var client = _httpClientFactory.CreateClient();
                using var request =
                    new HttpRequestMessage(HttpMethod.Post, "https://identity.apaleo.com/connect/token");
                request.Headers.Add("Authorization", $"Basic {encodedCredentials}");

                request.Content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.SendAsync(request);

                AuthenticatedClientDto authenticatedClient = null;
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStringAsync();
                    authenticatedClient = JsonConvert.DeserializeObject<AuthenticatedClientDto>(responseStream);
                }

                return authenticatedClient;
            }
            catch (Exception ex)
            {
                return new AuthenticatedClientDto();
            }
        }
    }
}