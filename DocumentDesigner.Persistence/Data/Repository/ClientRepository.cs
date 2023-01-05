using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using DocumentDesigner.Persistence.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDesigner.Persistence.Data.Repository
{
	class ClientRepository : IClientRepository
	{
		private readonly DocumentDisegnerContext _dbContext;

		public ClientRepository(DocumentDisegnerContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateClient(Client client)
		{
			var clientDb = new Clients();
			clientDb.Name = client.Name;
			clientDb.Syrname = client.Syrname;
			clientDb.Patronymic = client.Patronymic;
			clientDb.Password = client.Password;
			clientDb.Email = client.Email;

			await _dbContext.AddAsync(clientDb);
		}

		public Task<Client> GetClient(string email, string password)
		{
			throw new NotImplementedException();
		}

		public Task<Client> GetClientByID(int clientID)
		{
			throw new NotImplementedException();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
