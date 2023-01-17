using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using DocumentDesigner.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
			var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Email == clientEmail);

			if (client != null)
				return client.MapInDomainClient();

			return null;
		}

		public async Task<JuridicalPerson> GetJuridicalPersonById(int juridicalPersonID)
		{
			return (await _dbContext.JuridicalPersons.FirstOrDefaultAsync(j => j.JuridicalPersonId == juridicalPersonID))
				.MapInDomainJuridicalPerson();
		}

		public async Task<IReadOnlyCollection<JuridicalPerson>> GeJuridicalPersonForClient(string clientEmail)
		{
			var client = await GetClientByEmail(clientEmail);
			var juridicalPerson = await _dbContext.JuridicalPersonIsClient
				.Include(j => j.JuridicalPerson)
				.Where(j => j.ClientId == client.ClientID)
				.ToListAsync();

			return juridicalPerson.Select(j => j.JuridicalPerson.MapInDomainJuridicalPerson()).ToArray();
		}

		public async Task AddJuridicalPerson(string clientEmail, JuridicalPerson juridicalPerson)
		{
			var jp = await GetJuridicalPersonByInn(juridicalPerson.Inn);
			if (jp != null)
			{
				var client = await GetClientByEmail(clientEmail);
				_dbContext.JuridicalPersonIsClient
					.Add(new Models.JuridicalPersonIsClient { ClientId = client.ClientID, JuridicalPersonId = jp.JuridicalPersonId });

				await _dbContext.SaveChangesAsync();
			}
			else
			{
				var jpNew = juridicalPerson.MapFromDomainJuridicalPerson();
				_dbContext.JuridicalPersons.Add(jpNew);

				await _dbContext.SaveChangesAsync();

				var client = await GetClientByEmail(clientEmail);
				_dbContext.JuridicalPersonIsClient
					.Add(new Models.JuridicalPersonIsClient { ClientId = client.ClientID, JuridicalPersonId = jpNew.JuridicalPersonId });

				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task DeleteJuridicalPerson(int juridicalPersonID)
		{
			var jp = await _dbContext.JuridicalPersonIsClient.Where(j => j.JuridicalPersonId == juridicalPersonID)
				.ToArrayAsync();

			_dbContext.JuridicalPersonIsClient.RemoveRange(jp);

			await _dbContext.SaveChangesAsync();
		}

		public async Task<JuridicalPerson> GetJuridicalPersonByInn(string inn)
		{
			var jp = await _dbContext.JuridicalPersons.FirstOrDefaultAsync(j => j.Inn == inn);
			if (jp != null)
				return jp.MapInDomainJuridicalPerson();

			return null;
		}

		public async Task<IReadOnlyCollection<PhysicalPerson>> GetPhysicalPersons(string clientEmail)
		{
			var client = await GetClientByEmail(clientEmail);
			var physicalPersons = await _dbContext.PhysicalPersons
				.Where(p => p.ClientId == client.ClientID)
				.Select(p => p.MapInDomainPhysicalPerson())
				.ToArrayAsync();

			return physicalPersons;
		}

		public async Task CreatePhysicalPerson(string clientEmail, PhysicalPerson physicalPerson)
		{
			var client = await GetClientByEmail(clientEmail);
			physicalPerson.ClientId = client.ClientID;
			physicalPerson.FullName = physicalPerson.Name + ' ' + physicalPerson.Patronymic + ' ' + physicalPerson.Syrname;
			physicalPerson.ShortName = physicalPerson.Syrname + ". " + physicalPerson.Name[0] + ". " +
				 (physicalPerson.Patronymic != null ? physicalPerson.Patronymic[0] : ' ');

			_dbContext.PhysicalPersons.Add(physicalPerson.MapFromDomainPhysicalPerson());

			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdatePhysicalPerson(string clientEmail, PhysicalPerson physicalPerson)
		{
			var client = await GetClientByEmail(clientEmail);
			var pp = _dbContext.PhysicalPersons.FirstOrDefault(p => p.PhysicalPersonId == physicalPerson.PhysicalPersonId);
			pp.Name = physicalPerson.Name;
			pp.Patronymic = physicalPerson.Patronymic;
			pp.Syrname = physicalPerson.Syrname;
			pp.ClientId = client.ClientID;
			pp.FullName = physicalPerson.Name + ' ' + physicalPerson.Patronymic + ' ' + physicalPerson.Syrname;
			pp.ShortName = physicalPerson.Syrname + ". " + physicalPerson.Name[0] + ". " +
				 (physicalPerson.Patronymic != null ? physicalPerson.Patronymic[0] : ' ');

			await _dbContext.SaveChangesAsync();
		}

		public async Task DeletePhysicalPerson(int physicalPersonId)
		{
			var pp = await _dbContext.PhysicalPersons.FirstOrDefaultAsync(p => p.PhysicalPersonId == physicalPersonId);

			_dbContext.PhysicalPersons.Remove(pp);

			await _dbContext.SaveChangesAsync();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
