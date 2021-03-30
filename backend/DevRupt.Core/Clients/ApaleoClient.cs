using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DevRupt.Core.Configuration;
using DevRupt.Core.Helpers;
using DevRupt.Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DevRupt.Core.Clients
{
    public class ApaleoClient : IApaleoClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApaleoClientCredentials> _options;

        public ApaleoClient(HttpClient httpClient, IOptions<ApaleoClientCredentials> options)
        {
            _httpClient = httpClient;
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

                using var request =
                    new HttpRequestMessage(HttpMethod.Post, "https://identity.apaleo.com/connect/token");
                request.Headers.Add("Authorization", $"Basic {encodedCredentials}");

                request.Content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await _httpClient.SendAsync(request);

                AuthenticatedClientDto authenticatedClient = null;
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    authenticatedClient = JsonConvert.DeserializeObject<AuthenticatedClientDto>(responseString);
                }

                return authenticatedClient;
            }
            catch (Exception ex)
            {
                return new AuthenticatedClientDto();
            }
        }

        public async Task<IEnumerable<Reservation>> GetReservationsFromDate(AuthenticatedClientDto authClient, DateTimeOffset date)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"dateFilter", "Creation"},
                {"expand","services"},
                {"from", date.ToString("yyyy-MM-ddTHH:mm:sszzz")},
                {"to", DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")}
            };
            
            try
            {
                const string uri = "booking/v1/reservations";
                var uriWithParams = QueryHelpers.AddQueryString(uri, queryParams);
            
                using var request = new HttpRequestMessage(HttpMethod.Get, uriWithParams);
                request.Headers.Add("Authorization", $"Bearer {authClient.AccessToken}");

                var response = await _httpClient.SendAsync(request);
            
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var reservations = JsonConvert.DeserializeObject<ReservationList>(responseString);
                    return reservations.Reservations;
                }
            }
            catch (Exception ex)
            {
                
            }
            return new List<Reservation>();
        }

       

        /// <summary>
        /// Reservations from booking API doesn't include folios which will have information on amount of breakfasts
        /// need to call folio API for each reservation to get the breakfasts attached to booking
        /// </summary>
        public async Task AddFoliosToReservations(AuthenticatedClientDto authClient, IEnumerable<Reservation> reservations)
        {
            const string uri = "finance/v1/folios";

            foreach (var reservation in reservations)
            {
                 // get all folios for a reservation - default folio created is reservationNo-1
                 var defaultFolioId = $"{reservation.Id}-1";
                 try
                 {
                     var defaultFolio =
                         await GetFolioForReservation(defaultFolioId, uri, authClient.AccessToken);

                     reservation.Folios ??= new List<Folio>();
                     reservation.Folios.Add(defaultFolio);

                     // if there any related folios, retrieve them and add to reservation
                     if (defaultFolio.RelatedFolios.Any())
                     {
                         foreach (var relatedFolio in defaultFolio.RelatedFolios)
                         {
                             var folio = await GetFolioForReservation(relatedFolio.Id, uri,
                                 authClient.AccessToken);
                             reservation.Folios.Add(folio);
                         }
                     }
                 }
                 catch (Exception)
                 {
                     
                 }
            }
        }

        private async Task<Folio> GetFolioForReservation(string folioId, string uri ,string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{uri}/{folioId}");
            request.Headers.Add("Authorization", $"Bearer {accessToken}");
            
            try
            {
                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var folio = JsonConvert.DeserializeObject<Folio>(responseString);
                    return folio;
                }
            }
            catch (Exception)
            {
                
            }

            return new Folio();
        }
    }
}