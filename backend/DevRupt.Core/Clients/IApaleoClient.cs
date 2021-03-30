using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Clients
{
    public interface IApaleoClient
    {
        Task<AuthenticatedClientDto> AuthenticateClient();
        Task<IEnumerable<Reservation>> GetReservationsFromDate(AuthenticatedClientDto client, DateTimeOffset date);
        Task AddFoliosToReservations(AuthenticatedClientDto client, IEnumerable<Reservation> reservations);

    }
}