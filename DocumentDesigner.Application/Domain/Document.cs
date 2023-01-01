using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDesigner.Application.Domain
{
	public class Document
	{
		public int DocumentID { get; set; }

		public string Name { get; set; }

		public GroupDocument Group { get; set; }

		public IReadOnlyCollection<HistoryDocument> HistoryDocuments { get; set; }
	}
}
