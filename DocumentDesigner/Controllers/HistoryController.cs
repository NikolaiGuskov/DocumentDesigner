using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentDesigner.Application.Data;
using DocumentDesigner.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentDesigner.WebApi.Controllers
{
	public class HistoryController : Controller
	{
		private readonly ContextData _contextData;

		public HistoryController(ContextData contextData)
		{
			_contextData = contextData;
		}

		public async Task<IActionResult> IndexAsync()
		{
			var history = await _contextData.Documents.GetDocumentsForClient(User.Identity.Name);

			return View(history);
		}

		public async Task<IActionResult> DeleteHistoryAsync(int historyID)
		{
			await _contextData.Documents.DeleteHistory(historyID);

			var history = await _contextData.Documents.GetDocumentsForClient(User.Identity.Name);

			return View(history);
		}
	}
}
