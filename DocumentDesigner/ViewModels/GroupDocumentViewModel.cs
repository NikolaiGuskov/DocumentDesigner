using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.ViewModels
{
	public class GroupDocumentViewModel
	{
		public int GroupID { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public IReadOnlyCollection<Document> Documents { get; set; }
	}
}
