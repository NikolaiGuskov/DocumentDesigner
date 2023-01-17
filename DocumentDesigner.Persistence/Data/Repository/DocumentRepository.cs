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
			history.CreateDate = DateTime.Now;

			_dbContext.HistoryDocuments.Add(history);
		}

		public async Task<IReadOnlyCollection<GroupDocument>> GetAllGroupDocumentWithDocuments()
		{
			return (await _dbContext.GroupDocuments
				.Include(g => g.Documents)
				.ToArrayAsync())
				.Select(g => g.MapInDomainGroupDocument())
				.ToArray();
		}

		public async Task<Document> GetDocumentByID(int documentID)
		{
			return (await _dbContext.Documents.Include(d => d.Group)
				.FirstOrDefaultAsync(d => d.DocumentId == documentID))
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

		public async Task<IReadOnlyCollection<HistoryDocument>> GetDocumentsForClient(string clientEmail)
		{
			var client = await _clientRepository.GetClientByEmail(clientEmail);
			var history = await _dbContext.HistoryDocuments
				.Include(h => h.Document)
					.ThenInclude(d => d.Group)
				.Where(h => h.ClientId == client.ClientID)
				.ToArrayAsync();

			return history.Select(h => h.MapInDomainHistoryDocument()).ToArray();
		}

		public async Task DeleteHistory(int historyID)
		{
			var history = _dbContext.HistoryDocuments.Find(historyID);

			_dbContext.HistoryDocuments.Remove(history);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
