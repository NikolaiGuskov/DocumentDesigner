using System.Threading.Tasks;
using DocumentDesigner.Application.Data;
using DocumentDesigner.WebApi.Mappers;
using DocumentDesigner.WebApi.Service;
using DocumentDesigner.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DocumentDesigner.WebApi.Controllers
{
	public class AuthenticationController : Controller
	{
        public readonly ContextData _contextData;

		private readonly IAuthenticationService _authenticationService;

		public AuthenticationController(ContextData contextData, IAuthenticationService authenticationService)
		{
            _contextData = contextData;
			_authenticationService = authenticationService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
			if (ModelState.IsValid)
			{
				var user = await _contextData.Clients
					.GetClient(loginModel.Email, loginModel.Password)
					.ConfigureAwait(false);

				if (user != null)
				{
					await _authenticationService
						.SetAuthenticationCookies(loginModel.Email)
						.ConfigureAwait(false);

					return RedirectToAction("Index", "Document");
				}
			}

			ModelState.AddModelError("", "Некорректные логин и(или) пароль");

			return View(loginModel);
        }

		[HttpGet]
		public IActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Registration(RegistrationViewModel registrationModel)
		{
			if (ModelState.IsValid)
			{
				var client = await _contextData.Clients
					.GetClientByEmail(registrationModel.Email)
					.ConfigureAwait(false);

				if (client != null)
				{
					ModelState.AddModelError("", "Клиент с таким Email уже есть");

					return View(registrationModel);
				}

				await _contextData.Clients
					.CreateClient(registrationModel.MapFromRegistrationViewModel())
					.ConfigureAwait(false);

				await _authenticationService
					.SetAuthenticationCookies(registrationModel.Email)
					.ConfigureAwait(false);

				await _contextData.SaveChangesAsync();

				return RedirectToAction("Index", "Document");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _authenticationService
				.DeleteAuthenticationCookies()
				.ConfigureAwait(false);

			return RedirectToAction("Login", "Authentication");
		}
	}
}
