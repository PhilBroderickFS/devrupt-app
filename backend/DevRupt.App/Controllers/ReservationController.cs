using Microsoft.AspNetCore.Mvc;
using DevRupt.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevRupt.App.Controllers
{
    public class ReservationController : Controller
    {

        private readonly IHttpClientFactory _httpclientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpclientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var user = Authenticate();

            if (user == null)
                return View();

            List<Reservation> reservationList = new List<Reservation>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.apaleo.com/booking/v1/reservations"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                }
            }
            return View(reservationList);
        }
    

        [HttpPost]
        public async Task<IActionResult> GetReservation(int id)
        {
            Reservation reservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.apaleo.com/booking/v1/reservations/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(reservation);
        }


        public async Task<AuthenticatedClient> Authenticate()
        {
            try
            {
                var body = "grant_type=client_credentials";
                var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("LAIK-SP-TYSJOSH:odUZ00NCDp1Krty3MdNI4vbt1JW6Sl"));

                var client = _httpclientFactory.CreateClient();

                using var request = new HttpRequestMessage(HttpMethod.Post, "https://identity.apaleo.com/connect/token");
                request.Headers.Add("Authorization", $"Basic {encodedCredentials}");

                request.Content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.SendAsync(request);

                AuthenticatedClient authenticatedClient = null;
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStringAsync();
                    authenticatedClient = JsonConvert.DeserializeObject<AuthenticatedClient>(responseStream);
                }

                return authenticatedClient;
            }
            catch (Exception)
            {
                return new AuthenticatedClient();
            }
        }
    }
}
