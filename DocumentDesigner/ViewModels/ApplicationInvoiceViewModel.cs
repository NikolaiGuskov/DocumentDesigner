using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class ApplicationInvoiceViewModel
	{
		public int Numberinvoice { get; set; }

		public string ToWhom { get; set; }

		public string FromWhom { get; set; }

		public string ToWhomNom { get; set; }

		public string FromWhomNom { get; set; }

		public List<InvoiceProductViewModel> Products { get; set; }
	}
}
