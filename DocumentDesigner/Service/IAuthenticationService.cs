using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.Service
{
	/// <summary>
	/// Сервис авторизации пользователей.
	/// </summary>
	public interface IAuthenticationService
	{
		/// <summary>
		/// Установка аутентификационных куки.
		/// </summary>
		/// <param name="clientEmail">Email клиента.</param>
		public Task SetAuthenticationCookies(string clientEmail);
	}
}
