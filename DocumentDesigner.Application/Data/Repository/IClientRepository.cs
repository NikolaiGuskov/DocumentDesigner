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

		Task<IReadOnlyCollection<JuridicalPerson>> GeJuridicalPersonForClient(string clientEmail);

		Task AddJuridicalPerson(string clientEmail, JuridicalPerson juridicalPerson);

		Task DeleteJuridicalPerson(int juridicalPersonID);

		Task<JuridicalPerson> GetJuridicalPersonByInn(string inn);

		Task DeletePhysicalPerson(int physicalPersonId);

		Task UpdatePhysicalPerson(string clientEmail, PhysicalPerson physicalPerson);

		Task CreatePhysicalPerson(string clientEmail, PhysicalPerson physicalPerson);

		Task<IReadOnlyCollection<PhysicalPerson>> GetPhysicalPersons(string clientEmail);

		Task<int> SaveChangesAsync();
	}
}
