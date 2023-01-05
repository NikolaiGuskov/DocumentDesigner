using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentDesigner.Persistence.Mappers;
using DocumentDesigner.Persistence.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DocumentDesigner.Persistence.Data.Repository
{
	public class DocumentRepository : IDocumentRepository
	{
		private readonly DocumentDisegnerContext _dbContext;

		private readonly IClientRepository _clientRepository;

		public DocumentRepository(DocumentDisegnerContext dbContext, 
			IClientRepository clientRepository)
		{
			_dbContext = dbContext;
			_clientRepository = clientRepository;
		}

		public async Task AddDocumentsClient(int documentID, string clientEmail)
		{
			var document = await GetDocumentByID(documentID);
			var client = (await _clientRepository.GetClientByEmail(clientEmail)).MapFromDomainClient();

			var history = new HistoryDocuments();
			history.ClientId = client.ClientId;
			history.DocumentId = document.DocumentID;

			_dbContext.HistoryDocuments.Add(history);
		}

		public async Task<IReadOnlyCollection<GroupDocument>> GetAllGroupDocumentWithDocuments()
		{
			throw new NotImplementedException();
		}

		public async Task<Document> GetDocumentByID(int documentID)
		{
			return (await _dbContext.Documents.FirstOrDefaultAsync(d => d.DocumentId == documentID))
				.MapInDomainDocument();
		}

		public async Task<IReadOnlyCollection<Document>> GetDocumentsForClient(int clientID)
		{
			var documents = _dbContext.Documents
				.Include(d => d.HistoryDocuments)
				.Where(d => d.HistoryDocuments.Any(h => h.ClientId == clientID));

			return (await documents.ToArrayAsync())
				.Select(d => d.MapInDomainDocument())
				.ToArray();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
