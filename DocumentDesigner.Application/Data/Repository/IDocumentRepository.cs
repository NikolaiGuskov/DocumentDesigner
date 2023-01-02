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

		Task AddDocementsClient(int documentID, int clientID);

		Task<Document> GetDocumentByID(int documentID);
	}
}
