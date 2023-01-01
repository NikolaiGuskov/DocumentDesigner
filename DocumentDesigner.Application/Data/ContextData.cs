using System.Threading;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Data
{
	public class ContextData
	{
		private readonly IDocumentDesignerDbContext _documentDesignerDbContext;

		private readonly IClientRepository _clientRepository;

		private readonly IDocumentRepository _documentRepository;

		public ContextData(
			IDocumentDesignerDbContext documentDesignerDbContext, 
			IClientRepository clientRepository,
			IDocumentRepository documentRepository)
		{
			_documentDesignerDbContext = documentDesignerDbContext;
			_clientRepository = clientRepository;
			_documentRepository = documentRepository;
		}

		public IClientRepository Clients => _clientRepository;

		public IDocumentRepository Documents => _documentRepository;

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{
			return await _documentDesignerDbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
