using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocumentDesigner.Models;
using DocumentDesigner.WebApi.Mappers;
using DocumentDesigner.Application.Handlers.Interfaces;
using DocumentDesigner.WebApi.ViewModels;

namespace DocumentDesigner.Controllers
{
	public class DocumentController : Controller
	{
		public readonly IDocumentHandler _documentHandler;

		public DocumentController(IDocumentHandler documentHandler)
		{
			_documentHandler = documentHandler;
		}

		// [Authorize]
		public async Task<IActionResult> IndexAsync()
		{
			var groupsDocument = await _documentHandler.GetAllGroupDocumentWithDocuments();
			var view = new GroupDocumentViews(groupsDocument.Select(g => g.MapInGroupDocumentView()).ToArray());

			return View(view);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
