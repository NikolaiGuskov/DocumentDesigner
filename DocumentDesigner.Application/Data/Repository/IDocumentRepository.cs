using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Data
{
	public interface IDocumentRepository
	{
		public Task<IReadOnlyCollection<GroupDocument>> GetAllGroupDocumentWithDocuments();

		public Task<IReadOnlyCollection<Document>> GetDocumentsForClient(int clientID);
	}
}
