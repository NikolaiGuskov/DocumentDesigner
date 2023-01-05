using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentDesigner.WebApi.Controllers
{
	public class HistoryController : Controller
	{
		public async Task<IActionResult> IndexAsync()
		{
			return View();
		}
	}
}
