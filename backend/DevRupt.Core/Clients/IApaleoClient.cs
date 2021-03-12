using System.Threading.Tasks;
using DevRupt.Core.Models;

namespace DevRupt.Core.Clients
{
    public interface IApaleoClient
    {
        Task<AuthenticatedClientDto> AuthenticateClient();
    }
}