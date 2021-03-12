using System;
using System.Threading;
using System.Threading.Tasks;
using DevRupt.Core.Clients;
using Microsoft.Extensions.Hosting;

namespace DevRupt.Core.Services
{
    public class ReservationProcessor : IHostedService
    {
        private readonly IApaleoClient _apaleoClient;
        private TimeSpan _interval;
        private Timer _timer;

        public ReservationProcessor(IApaleoClient apaleoClient)
        {
            _apaleoClient = apaleoClient;
            _interval = TimeSpan.FromMinutes(1);
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(ProcessReservations, null, TimeSpan.Zero, _interval);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void ProcessReservations(object state) => _ = ProcessReservationsAsync();

        private async Task ProcessReservationsAsync()
        {
            var authenticatedClient = await _apaleoClient.AuthenticateClient();
            
            // check most recent reservation in local storage DB
            
            // retrieve all new/update reservations
            
            // save to DB
        }
    }
}