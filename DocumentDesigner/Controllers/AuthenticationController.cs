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

        public async Task<IActionResult> Authentication()
        {
            //if (ModelState.IsValid)
            //{
            //    var user = Controllers.User.Users.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
            //    if (user != null)
            //    {
            //        await Authenticate(loginModel.Email);

            //        // return RedirectToAction("Index", "Document");
            //    }

            //    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            //}

            return View();
        }
    }
}
