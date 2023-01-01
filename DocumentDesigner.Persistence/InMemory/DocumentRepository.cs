using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDesigner.Persistence.InMemory
{
	public class DocumentRepository : IDocumentRepository
	{
		static List<Document> _documents = new List<Document>();

		public async Task<IReadOnlyCollection<GroupDocument>> GetAllGroupDocumentWithDocuments()
		{
			return await Task.Run(() =>
			{
				var d1 = new GroupDocument
				{
					GroupID = 1,
					Description = "распорядительные документы; первичные учетные документы по учету кадров, рабочего времени и оплаты труда; информационно-справочные документы; «архивные» документы",
					Title = "Документы по кадровым функциям",
					Documents = new List<Document>
					{
						new Document
						{
							DocumentID = 1,
							Name = "Заявление на увольнение"					
						},
						new Document
						{
							DocumentID = 2,
							Name = "Заявление при трудоустройстве на работу"
						},
						new Document
						{
							DocumentID = 3,
							Name = "Заявление повышение в должности"
						}
					}
				};

				var d2 = new GroupDocument
				{
					GroupID = 2,
					Description = "распорядительные документы; первичные учетные документы по учету кадров, рабочего времени и оплаты труда; информационно-справочные документы; «архивные» документы",
					Title = "Документы по кадровым функциям",
					Documents = new List<Document>
					{
						new Document
						{
							DocumentID = 4,
							Name = "Заявление на увольнение"
						},
						new Document
						{
							DocumentID = 5,
							Name = "Заявление при трудоустройстве на работу"
						}
					}
				};

				var groupDocument = new List<GroupDocument> { d1, d2 };

				return new ReadOnlyCollection<GroupDocument>(groupDocument);
			});
		}

		public Task<IReadOnlyCollection<Document>> GetDocumentsForClient(int clientID)
		{
			throw new NotImplementedException();
		}
	}
}
