using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDesigner.Application.Domain
{
	public class HistoryDocument
	{
		public int HistoryID { get; set; }

		public Client Client { get; set; }

		public Document Document { get; set; }

		public DateTime CreateDate { get; set; }
	}
}
