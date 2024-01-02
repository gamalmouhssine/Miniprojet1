using Miniprojet.Shared.Entites;

namespace Miniprojet.Server.Repositories
{
    public interface IClient
    {
        Task<List<Clients>> GetClientinContactdAsync(int clientId);
        Task<List<Clients>> GetClientsAsync();
        Task<Clients> GetClientByIdAsync(int clientId);
        Task<int> AddClientAsync(Clients client);
        Task DeleteClientAsync(int clientId);
        Task UpdateClientAsync(int idclient, Clients client);
    }
}
