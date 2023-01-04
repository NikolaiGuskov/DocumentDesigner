using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDesigner.Persistence.InMemory
{
	public class DocumentRepository : IDocumentRepository
	{
		private readonly IClientRepository _clientRepository;

		public DocumentRepository(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}

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
							Name = "Заявление на увольнение",
							ViewName = "ApplicationDismissal"
						},
						new Document
						{
							DocumentID = 2,
							Name = "Служебная записка о повышении в должности",
							ViewName = "ApplicationPromotion"
						}
					}
				};

				var d2 = new GroupDocument
				{
					GroupID = 2,
					Description = "Первичные документы для двух сторон, которые служат подтверждением факта заключения и исполнения сделки, ее стоимости и сроков исполнения",
					Title = "Бухалтерские акты",
					Documents = new List<Document>
					{
						new Document
						{
							DocumentID = 4,
							Name = "Накладная",
							ViewName = "ApplicationInvoice"
						}
					}
				};

				var groupDocument = new List<GroupDocument> { d1, d2 };

				_documents.AddRange(d1.Documents);
				_documents.AddRange(d2.Documents);

				return new ReadOnlyCollection<GroupDocument>(groupDocument);
			});
		}

		public async Task AddDocementsClient(int documentID, int clientID)
		{
			var document = _documents.FirstOrDefault(d => d.DocumentID == documentID);
			var client = await _clientRepository.GetClientByID(clientID);

			document.HistoryDocuments = new List<HistoryDocument>()
			{
				new HistoryDocument
				{
					Client = client,
					Document = document
				}
			};
		}

		public async Task<Document> GetDocumentByID(int documentID)
		{
			return await Task.Run(() => _documents.FirstOrDefault(d => d.DocumentID == documentID));
		}

		public Task<IReadOnlyCollection<Document>> GetDocumentsForClient(int clientID)
		{
			throw new NotImplementedException();
		}
	}
}
