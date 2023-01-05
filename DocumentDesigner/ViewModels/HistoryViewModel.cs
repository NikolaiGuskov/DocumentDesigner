using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class HistoryViewModel
	{
		public int HistoryID { get; set; }

		public string Document { get; set; }

		public DateTime Date { get; set; }
	}
}
