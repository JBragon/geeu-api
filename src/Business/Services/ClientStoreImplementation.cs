using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Business.Services
{
    public class ClientStoreImplementation : IClientStore
    {
        // Exemplo de uma lista de clientes em memória
        private static List<Client> _clients = new List<Client>
    {
        new Client
        {
            ClientId = "client1",
            ClientName = "Client 1",
            // outras propriedades do cliente...
        },
        new Client
        {
            ClientId = "client2",
            ClientName = "Client 2",
            // outras propriedades do cliente...
        }
    };

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = _clients.FirstOrDefault(c => c.ClientId == clientId);
            return Task.FromResult(client);
        }
    }
}
