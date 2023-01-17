using DocumentDesigner.Application.Domain;
using DocumentDesigner.Persistence.Data.Models;

namespace DocumentDesigner.Persistence.Mappers
{
	public static class ClientMapper
	{
		public static Clients MapFromDomainClient(this Client client)
		{
			return new Clients
			{
				Name = client.Name,
				Syrname = client.Syrname,
				Patronymic = client.Patronymic,
				Password = client.Password,
				Email = client.Email,
				ClientId = client.ClientID
			};
		}

		public static Client MapInDomainClient(this Clients client)
		{
			return new Client
			{
				ClientID = client.ClientId,
				Name = client.Name,
				Syrname = client.Syrname,
				Patronymic = client.Patronymic,
				Password = client.Password,
				Email = client.Email
			};
		}

		public static JuridicalPerson MapInDomainJuridicalPerson(this JuridicalPersons juridicalPerson)
		{
			return new JuridicalPerson
			{
				JuridicalPersonId = juridicalPerson?.JuridicalPersonId ?? 0,
				Inn = juridicalPerson.Inn,
				Address = juridicalPerson.Address,
				Name = juridicalPerson.Name,
				Phone = juridicalPerson.Phone
			};
		}

		public static JuridicalPersons MapFromDomainJuridicalPerson(this JuridicalPerson juridicalPerson)
		{
			return new JuridicalPersons
			{
				JuridicalPersonId = juridicalPerson.JuridicalPersonId,
				Inn = juridicalPerson.Inn,
				Address = juridicalPerson.Address,
				Name = juridicalPerson.Name,
				Phone = juridicalPerson.Phone
			};
		}

		public static PhysicalPerson MapInDomainPhysicalPerson(this PhysicalPersons physicalPerson)
		{
			return new PhysicalPerson
			{
				PhysicalPersonId = physicalPerson.PhysicalPersonId,
				Name = physicalPerson.Name,
				Patronymic = physicalPerson.Patronymic,
				Syrname = physicalPerson.Syrname,
				ShortName = physicalPerson.ShortName,
				FullName = physicalPerson.FullName,
				ClientId = physicalPerson.ClientId
			};
		}

		public static PhysicalPersons MapFromDomainPhysicalPerson(this PhysicalPerson physicalPerson)
		{
			return new PhysicalPersons
			{
				PhysicalPersonId = physicalPerson.PhysicalPersonId,
				Name = physicalPerson.Name,
				Patronymic = physicalPerson.Patronymic,
				Syrname = physicalPerson.Syrname,
				ShortName = physicalPerson.ShortName,
				FullName = physicalPerson.FullName,
				ClientId = physicalPerson.ClientId
			};
		}
	}
}
