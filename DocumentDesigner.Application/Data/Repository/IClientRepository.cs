using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Data
{
	public interface IClientRepository
	{
		Task<Client> GetClient(string email, string password);

		Task CreateClient(Client client);


		Task<Client> GetClientByID(int clientID);

		Task<Client> GetClientByEmail(string clientEmail);

		Task<int> SaveChangesAsync();
	}
}
