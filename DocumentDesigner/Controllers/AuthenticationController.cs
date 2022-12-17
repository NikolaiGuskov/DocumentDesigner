using System.Threading.Tasks;
using DocumentDesigner.Application.Data;
using DocumentDesigner.WebApi.Service;
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
		public async Task<IActionResult> Authentication()
        {
			if (ModelState.IsValid)
			{
				var user = await _contextData.Clients
					.GetClient(null, null)
					.ConfigureAwait(false);

				if (user != null)
				{
					await _authenticationService
						.SetAuthenticationCookies(null)
						.ConfigureAwait(false);

					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError("", "Некорректные логин и(или) пароль");
			}

			return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Registration()
		{
			if (ModelState.IsValid)
			{
				await _contextData.Clients.CreateClient(null).ConfigureAwait(false);

				await _authenticationService
					.SetAuthenticationCookies(null)
					.ConfigureAwait(false);

				return RedirectToAction("Index", "Home");
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
