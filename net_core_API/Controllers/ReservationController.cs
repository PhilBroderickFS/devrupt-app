using Microsoft.AspNetCore.Mvc;
using net_core_API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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
            List<Reservation> reservationList = new List<Reservation>();

            var httpClient = _httpclientFactory.CreateClient("apaleo");
            var URL = $"/booking/v1/reservations";

            var response = await httpClient.GetAsync("URL");

            string apiResponse = await response.Content.ReadAsStringAsync();
            reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);

            return View(reservationList);

        }


        public async Task<IActionResult> Detail(string id)
        {
            Reservation reservation = new Reservation();

            var httpClient = _httpclientFactory.CreateClient("apaleo");
            var URL = $"/booking/v1/reservations/{id}";

            var response = await httpClient.GetAsync("URL");

            string apiResponse = await response.Content.ReadAsStringAsync();
            reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);

            return View(reservation);

        }
    }
}
