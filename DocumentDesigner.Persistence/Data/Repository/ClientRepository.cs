using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using DocumentDesigner.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.Persistence.Data.Repository
{
	public class ClientRepository : IClientRepository
	{
		private readonly DocumentDisegnerContext _dbContext;

		public ClientRepository(DocumentDisegnerContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateClient(Client client)
		{
			await _dbContext.AddAsync(client.MapFromDomainClient());
		}

		public async Task<Client> GetClient(string email, string password)
		{
			return (await _dbContext.Clients
				.FirstOrDefaultAsync(c => c.Email == email && c.Password == password))
				.MapInDomainClient();
		}

		public async Task<Client> GetClientByID(int clientID)
		{
			return (await _dbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == clientID))
				.MapInDomainClient();
		}

		public async Task<Client> GetClientByEmail(string clientEmail)
		{
			return (await _dbContext.Clients.FirstOrDefaultAsync(c => c.Email == clientEmail))
				.MapInDomainClient();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
