using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class InvoiceProductViewModel
	{
		public string Name { get; set; }

		public int Quantity { get; set; }

		public double Price { get; set; }
	}
}
