using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDesigner.Persistence.InMemory
{
	public class ClientRepository : IClientRepository
	{
		static List<Client> _clients = new List<Client>();

		public async Task CreateClient(Client client)
		{
			_clients.Add(client);

			await Task.FromResult(true);
		}

		public async Task<Client> GetClient(string email, string password)
		{
			var client = _clients.FirstOrDefault(c => c.Email == email && c.Password == c.Password);

			return await Task.FromResult(client);
		}

		public async Task<Client> GetClientByID(int clientID)
		{
			var client = _clients.FirstOrDefault(c => c.ClientID == clientID);

			return await Task.FromResult(client);
		}
	}
}
