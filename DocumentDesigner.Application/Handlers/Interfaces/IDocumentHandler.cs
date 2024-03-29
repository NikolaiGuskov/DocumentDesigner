﻿using DocumentDesigner.Application.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Handlers.Interfaces
{
	public interface IDocumentHandler
	{
		Task<IReadOnlyCollection<GroupDocument>> GetAllGroupDocumentWithDocuments();

		Task<Document> GetDocumentByID(int documentID);

		Task<byte[]> AddDocumentForClient(string clientEmail, int documentID, string html);

		Task<byte[]> GenerateDocumentInPDF(string html);
	}
}
