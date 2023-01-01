using DocumentDesigner.Application.Domain;
using DocumentDesigner.WebApi.ViewModels;

namespace DocumentDesigner.WebApi.Mappers
{
	public static class ClientMapper
	{
		public static Client MapFromRegistrationViewModel(this RegistrationViewModel registrationModel)
		{
			return new Client
			{
				Name = registrationModel.Name,
				Syrname = registrationModel.Surname,
				Patronymic = registrationModel.Patronymic,
				Password = registrationModel.Password,
				Email = registrationModel.Email
			};
		}
	}
}
