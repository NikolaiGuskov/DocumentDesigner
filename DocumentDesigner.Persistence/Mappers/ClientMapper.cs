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
				Email = client.Email
			};
		}

		public static Client MapInDomainClient(this Clients client)
		{
			return new Client
			{
				Name = client.Name,
				Syrname = client.Syrname,
				Patronymic = client.Patronymic,
				Password = client.Password,
				Email = client.Email
			};
		}
	}
}
