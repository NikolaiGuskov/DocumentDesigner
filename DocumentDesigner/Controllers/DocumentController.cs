using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocumentDesigner.Models;
using DocumentDesigner.WebApi.Mappers;
using DocumentDesigner.Application.Handlers.Interfaces;
using DocumentDesigner.WebApi.ViewModels;
using DocumentDesigner.WebApi.Service;
using Microsoft.AspNetCore.Authorization;
using NPetrovich;
using DocumentDesigner.Application.Data;

namespace DocumentDesigner.Controllers
{
	public class DocumentController : Controller
	{
		private readonly ContextData _contextData;

		private readonly IDocumentHandler _documentHandler;

		private readonly ICustomViewRendererService _customViewRendererService;

		public DocumentController(
			ContextData contextData,
			IDocumentHandler documentHandler, 
			ICustomViewRendererService customViewRendererService)
		{
			_contextData = contextData;
			_customViewRendererService = customViewRendererService;
			_documentHandler = documentHandler;
		}

		[Authorize]
		public async Task<IActionResult> IndexAsync()
		{
			var groupsDocument = await _documentHandler.GetAllGroupDocumentWithDocuments();
			var view = new GroupDocumentViewModels(groupsDocument.Select(g => g.MapInGroupDocumentView()).ToArray());

			return View(view);
		}

		public async Task<IActionResult> GetDocument(int? documentID)
		{
			var document = await _documentHandler.GetDocumentByID(documentID.Value);

			if (document.ViewName == "ApplicationDismissal")
			{
				var model = new ApplicationDismissalViewModel();
				model.PhysicalPersons = await _contextData.Clients.GetPhysicalPersons(User.Identity.Name);
				model.Companys = await _contextData.Clients.GeJuridicalPersonForClient(User.Identity.Name);

				return View(document.ViewName, model);
			}

			if (document.ViewName == "ApplicationPromotion")
			{
				var model = new ApplicationPromotionViewModel();
				model.PhysicalPersons = await _contextData.Clients.GetPhysicalPersons(User.Identity.Name);
				model.Companys = await _contextData.Clients.GeJuridicalPersonForClient(User.Identity.Name);

				return View(document.ViewName, model);
			}

			return View(document.ViewName);
		}

		[HttpPost]
		public async Task<IActionResult> GenerateDocumentDismissal(ApplicationDismissalViewModel model)
		{
			const string templatePath = "~/Views/Templates/ApplicationDismissal.cshtml";

			model.PhysicalPersons = await _contextData.Clients.GetPhysicalPersons(User.Identity.Name);
			model.Companys = await _contextData.Clients.GeJuridicalPersonForClient(User.Identity.Name);

			var directorName = model.PhysicalPersons.FirstOrDefault(p => p.PhysicalPersonId == model.DirectorID);
			var userName = model.PhysicalPersons.FirstOrDefault(p => p.PhysicalPersonId == model.EmployeesID);

			var director = new Petrovich()
			{
				FirstName = directorName.Name,
				LastName = directorName.Syrname,
				MiddleName = directorName.Patronymic
			};
			var user = new Petrovich()
			{
				FirstName = userName.Name,
				LastName = userName.Syrname,
				MiddleName = userName.Patronymic
			};

			model.DirectorName = director.InflectTo(Case.Dative).ToString();
			model.EmployeesNameTwo = user.InflectTo(Case.Accusative).ToString();

			var html = await _customViewRendererService.RenderViewToStringAsync(ControllerContext, templatePath, model);
			var documentFile = await _documentHandler.AddDocumentForClient(User.Identity.Name, 1, html);

			return File(documentFile, "application/pdf", "Заявление на увольнение.pdf");
		}

		[HttpPost]
		public async Task<IActionResult> GenerateDocumentPromotion(ApplicationPromotionViewModel model)
		{
			const string templatePath = "~/Views/Templates/ApplicationPromotion.cshtml";
			model.PhysicalPersons = await _contextData.Clients.GetPhysicalPersons(User.Identity.Name);
			model.Companys = await _contextData.Clients.GeJuridicalPersonForClient(User.Identity.Name);

			var directorName = model.PhysicalPersons.FirstOrDefault(p => p.PhysicalPersonId == model.DirectorID);
			var userName = model.PhysicalPersons.FirstOrDefault(p => p.PhysicalPersonId == model.EmployeesID);
			var promotionName = model.PhysicalPersons.FirstOrDefault(p => p.PhysicalPersonId == model.PromotionID);

			var director = new Petrovich()
			{
				FirstName = directorName.Name,
				LastName = directorName.Syrname,
				MiddleName = directorName.Patronymic
			};
			var user = new Petrovich()
			{
				FirstName = userName.Name,
				LastName = userName.Syrname,
				MiddleName = userName.Patronymic
			};
			var promotion = new Petrovich()
			{
				FirstName = promotionName.Name,
				LastName = promotionName.Syrname,
				MiddleName = promotionName.Patronymic
			};

			model.DirectorName = director.InflectTo(Case.Dative).ToString();
			model.EmployeesNameTwo = user.InflectTo(Case.Accusative).ToString();
			model.PromotionName = promotion.InflectTo(Case.Genitive).ToString();
			model.DirectorNameTwo = directorName.FullName;

			var html = await _customViewRendererService.RenderViewToStringAsync(ControllerContext, templatePath, model);
			var documentFile = await _documentHandler.AddDocumentForClient(User.Identity.Name, 2, html);

			return File(documentFile, "application/pdf", "Служебная записка о повышении в должности.pdf");
		}

		[HttpPost]
		public async Task<IActionResult> GenerateDocumentInvoice(ApplicationInvoiceViewModel model)
		{
			const string templatePath = "~/Views/Templates/ApplicationInvoice.cshtml";
			var toWhomNomName = model.ToWhom.Split(' ');
			var FromWhomNomName = model.FromWhom.Split(' ');

			var toWhomNom = new Petrovich()
			{
				FirstName = toWhomNomName[0],
				LastName = toWhomNomName[1],
				MiddleName = toWhomNomName.Count() > 2 ? toWhomNomName[2] : string.Empty
			};
			var fromWhomNom = new Petrovich()
			{
				FirstName = FromWhomNomName[0],
				LastName = FromWhomNomName[1],
				MiddleName = FromWhomNomName.Count() > 2 ? toWhomNomName[2] : string.Empty
			};

			model.ToWhomNom = toWhomNom.InflectTo(Case.Nominative).ToString();
			model.FromWhomNom = fromWhomNom.InflectTo(Case.Nominative).ToString();

			var html = await _customViewRendererService.RenderViewToStringAsync(ControllerContext, templatePath, model);
			var documentFile = await _documentHandler.AddDocumentForClient(User.Identity.Name, 3, html);

			return File(documentFile, "application/pdf", "Накладная.pdf");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
