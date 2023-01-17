using DocumentDesigner.Application.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class ApplicationDismissalViewModel
	{
		[Required(ErrorMessage = "Поле обязательно")]
		public string CompanyName { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public int DirectorID { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public string EmployeesPosition { get; set; }

		[Required(ErrorMessage = "Поле обязательно")]
		public int EmployeesID { get; set; }

		public string EmployeesNameTwo { get; set; }

		public string DirectorName { get; set; }

		public string EmployeesName { get; set; }

		public IReadOnlyCollection<JuridicalPerson> Companys { get; set; }

		public IReadOnlyCollection<PhysicalPerson> PhysicalPersons { get; set; }
	}
}
