using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DocumentDesigner.WebApi.Controllers
{
	public class AuthenticationController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
	}
}
