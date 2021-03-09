using Microsoft.AspNetCore.Mvc;
using net_core_API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace net_core_API.Controllers
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


        public async Task<User> Authenticate()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://identity.apaleo.com/connect/authorize");

            request.Content = new StringContent(JsonConvert.SerializeObject(
                new User() {UserName = "LAIK-SP-TYSJOSH", Password = "odUZ00NCDp1Krty3MdNI4vbt1JW6Sl" }));

            //request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var client = _httpclientFactory.CreateClient();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            User user = null;
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(responseStream);
            }

            return user;
        }
    }
}
