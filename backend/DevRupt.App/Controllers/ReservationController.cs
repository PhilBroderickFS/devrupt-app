using Microsoft.AspNetCore.Mvc;
using DevRupt.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevRupt.Core.Clients;

namespace DevRupt.App.Controllers
{
    public class ReservationController : Controller
    {

        private readonly IHttpClientFactory _httpclientFactory;
        private readonly IApaleoClient _apaleoClient;

        public ReservationController(IHttpClientFactory httpClientFactory, IApaleoClient apaleoClient)
        {
            _httpclientFactory = httpClientFactory;
            _apaleoClient = apaleoClient;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _apaleoClient.AuthenticateClient();

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
    }
}
