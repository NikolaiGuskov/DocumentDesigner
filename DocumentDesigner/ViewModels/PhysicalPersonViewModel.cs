using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class PhysicalPersonViewModel
	{
		public int PhysicalPersonId { get; set; }

		[Required(ErrorMessage = "Введите имя")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Введите фамилию")]
		public string Syrname { get; set; }

		public string Patronymic { get; set; }

		public bool IsUpdate { get; set; }
	}
}
