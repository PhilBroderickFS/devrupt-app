using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevRupt.Core.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevRupt.Core.Services
{
    public class ReservationProcessor : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IApaleoClient _apaleoClient;
        private IReservationService _reservationService;
        private TimeSpan _interval;
        private Timer _timer;

        public ReservationProcessor(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _interval = TimeSpan.FromHours(1);
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
            using var scope = _serviceScopeFactory.CreateScope();
            _apaleoClient = scope.ServiceProvider.GetRequiredService<IApaleoClient>();
            _reservationService = scope.ServiceProvider.GetRequiredService<IReservationService>();
            
            var authenticatedClient = await _apaleoClient.AuthenticateClient();
            
            var mostRecentReservationProcess = await _reservationService.GetMostRecentReservationProcess();

            if (mostRecentReservationProcess >= DateTime.Now.AddDays(-1))
            {
                return;
            }

            var recentReservations = (await _apaleoClient.GetReservationsFromDate(authenticatedClient, mostRecentReservationProcess)).ToList();

            if (recentReservations.Any())
            {
                await _apaleoClient.AddFoliosToReservations(authenticatedClient, recentReservations);
                await _reservationService.AddReservations(recentReservations);
            }
        }
    }
}