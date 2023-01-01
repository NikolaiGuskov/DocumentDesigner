using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDesigner.Application.Domain
{
	public class GroupDocument
	{
		public int GroupID { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public IReadOnlyCollection<Document> Documents { get; set; }
	}
}
