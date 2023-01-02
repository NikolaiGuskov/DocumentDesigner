using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Data
{
	public interface IClientRepository
	{
		public Task<Client> GetClient(string email, string password);

		public Task CreateClient(Client client);


		Task<Client> GetClientByID(int clientID);
	}
}
