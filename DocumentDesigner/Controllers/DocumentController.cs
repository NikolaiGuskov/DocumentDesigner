using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocumentDesigner.Models;
using DocumentDesigner.WebApi.Mappers;
using DocumentDesigner.Application.Handlers.Interfaces;
using DocumentDesigner.WebApi.ViewModels;
using DocumentDesigner.WebApi.Service;

namespace DocumentDesigner.Controllers
{
	public class DocumentController : Controller
	{
		private readonly IDocumentHandler _documentHandler;

		private readonly ICustomViewRendererService _customViewRendererService;

		public DocumentController(IDocumentHandler documentHandler, 
			ICustomViewRendererService customViewRendererService)
		{
			_customViewRendererService = customViewRendererService;
			_documentHandler = documentHandler;
		}

		// [Authorize]
		public async Task<IActionResult> IndexAsync()
		{
			var groupsDocument = await _documentHandler.GetAllGroupDocumentWithDocuments();
			var view = new GroupDocumentViewModels(groupsDocument.Select(g => g.MapInGroupDocumentView()).ToArray());

			return View(view);
		}

		public async Task<IActionResult> GetDocument(int? documentID)
		{
			var document = await _documentHandler.GetDocumentByID(documentID.Value);

			return View(document.ViewName);
		}

		[HttpPost]
		public async Task<IActionResult> GenerateDocumentDismissal(ApplicationDismissalViewModel model)
		{
			const string templatePath = "~/Views/Templates/ApplicationDismissal.cshtml";

			var html = await _customViewRendererService.RenderViewToStringAsync(ControllerContext, templatePath, model);
			var documentFile = await _documentHandler.GenerateDocumentInPDF(html);

			return File(documentFile, "application/pdf", "Заявление на увольнение.pdf");
		}

		[HttpPost]
		public async Task<IActionResult> GenerateDocumentPromotion(ApplicationPromotionViewModel model)
		{
			const string templatePath = "~/Views/Templates/ApplicationPromotion.cshtml";

			var html = await _customViewRendererService.RenderViewToStringAsync(ControllerContext, templatePath, model);
			var documentFile = await _documentHandler.GenerateDocumentInPDF(html);

			return File(documentFile, "application/pdf", "Служебная записка о повышении в должности.pdf");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
