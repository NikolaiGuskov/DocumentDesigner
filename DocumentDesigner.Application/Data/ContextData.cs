using System.Threading;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Data
{
	public class ContextData
	{
		private readonly IDocumentDesignerDbContext _documentDesignerDbContext;

		private readonly IClientRepository _clientRepository;

		public ContextData(
			IDocumentDesignerDbContext documentDesignerDbContext, 
			IClientRepository clientRepository)
		{
			_documentDesignerDbContext = documentDesignerDbContext;
			_clientRepository = clientRepository;
		}

		public IClientRepository Clients => _clientRepository;

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{
			return await _documentDesignerDbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
