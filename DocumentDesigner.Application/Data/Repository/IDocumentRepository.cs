using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Data
{
	public interface IDocumentRepository
	{
		Task<IReadOnlyCollection<GroupDocument>> GetAllGroupDocumentWithDocuments();

		Task<IReadOnlyCollection<Document>> GetDocumentsForClient(int clientID);

		Task AddDocumentsClient(int documentID, string clientEmail);

		Task<Document> GetDocumentByID(int documentID);

		Task<int> SaveChangesAsync();
	}
}
