using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class ApplicationPromotionViewModel
	{
		[Required(ErrorMessage = "Поле обязательно")]
		public string CompanyName { get; set; }

		public string DirectorName { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public string EmployeesPosition { get; set; }

		public string EmployeesName { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public string PromotionPosition { get; set; }

		public string PromotionName { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public string VacantPosition { get; set; }

		public string EmployeesNameTwo { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public int DirectorID { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public int EmployeesID { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public int PromotionID { get; set; }

		public string DirectorNameTwo { get; set; }

		public IReadOnlyCollection<JuridicalPerson> Companys { get; set; }

		public IReadOnlyCollection<PhysicalPerson> PhysicalPersons { get; set; }
	}
}
