using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using DocumentDesigner.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DocumentDesigner.WebApi.Controllers
{
	public class SettingController : Controller
	{
		private readonly ContextData _contextData;

		public SettingController(ContextData contextData)
		{
			_contextData = contextData;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetJuridicalPersons()
		{
			var jp = await _contextData.Clients.GeJuridicalPersonForClient(User.Identity.Name);

			return View(jp);
		}

		[HttpGet]
		public ActionResult AddJuridicalPerson()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddJuridicalPerson(JuridicalPersonViewModel juridicalPerson)
		{
			var jp = new JuridicalPerson();
			jp.Inn = juridicalPerson.Inn;
			jp.Name = juridicalPerson.Name;
			jp.Address = juridicalPerson.Address;
			jp.Phone = juridicalPerson.Phone;

			await _contextData.Clients.AddJuridicalPerson(User.Identity.Name, jp);

			return RedirectToAction("GetJuridicalPersons");
		}

		public async Task<IActionResult> DeleteJuridicalPerson(int juridicalPersonID)
		{
			await _contextData.Clients.DeleteJuridicalPerson(juridicalPersonID);

			var jp = await _contextData.Clients.GeJuridicalPersonForClient(User.Identity.Name);

			return View("GetJuridicalPersons", jp);
		}

		public async Task<IActionResult> GetPhysicalPersons()
		{
			var pp = await _contextData.Clients.GetPhysicalPersons(User.Identity.Name);

			return View(pp);
		}

		[HttpGet]
		public IActionResult CreatePhysicalPerson()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreatePhysicalPerson(PhysicalPersonViewModel person)
		{
			var ppDb = new PhysicalPerson();
			ppDb.Name = person.Name;
			ppDb.Syrname = person.Syrname;
			ppDb.Patronymic = person.Patronymic;

			await _contextData.Clients.CreatePhysicalPerson(User.Identity.Name, ppDb);

			var pp = await _contextData.Clients.GetPhysicalPersons(User.Identity.Name);

			return View("GetPhysicalPersons", pp);
		}

		[HttpGet]
		public async Task<IActionResult> UpdatePhysicalPerson(int physicalPersonId)
		{
			var pp = (await _contextData.Clients.GetPhysicalPersons(User.Identity.Name))
				.FirstOrDefault(p => p.PhysicalPersonId == physicalPersonId);

			var vm = new PhysicalPersonViewModel();
			vm.Name = pp.Name;
			vm.Syrname = pp.Syrname;
			vm.Patronymic = pp.Patronymic;
			vm.PhysicalPersonId = pp.PhysicalPersonId;
			vm.IsUpdate = true;

			return View("CreatePhysicalPerson", vm);
		}

		[HttpPost]
		public async Task<IActionResult> UpdatePhysicalPerson(PhysicalPersonViewModel person)
		{
			var ppDb = new PhysicalPerson();
			ppDb.Name = person.Name;
			ppDb.Syrname = person.Syrname;
			ppDb.Patronymic = person.Patronymic;
			ppDb.PhysicalPersonId = person.PhysicalPersonId;

			await _contextData.Clients.UpdatePhysicalPerson(User.Identity.Name, ppDb);

			var pp = await _contextData.Clients.GetPhysicalPersons(User.Identity.Name);

			return View("GetPhysicalPersons", pp);
		}

		public async Task<IActionResult> DeletePhysicalPerson(int physicalPersonId)
		{
			await _contextData.Clients.DeletePhysicalPerson(physicalPersonId);

			var pp = await _contextData.Clients.GetPhysicalPersons(User.Identity.Name);

			return View("GetPhysicalPersons", pp);
		}
	}
}
