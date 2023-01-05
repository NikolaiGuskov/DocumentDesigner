using System.Threading;
using System.Threading.Tasks;

namespace DocumentDesigner.Application.Data
{
	public class ContextData
	{
		private readonly IClientRepository _clientRepository;

		private readonly IDocumentRepository _documentRepository;

		public ContextData(
			IClientRepository clientRepository,
			IDocumentRepository documentRepository)
		{
			_clientRepository = clientRepository;
			_documentRepository = documentRepository;
		}

		public IClientRepository Clients => _clientRepository;

		public IDocumentRepository Documents => _documentRepository;

		public async Task<int> SaveChangesAsync()
		{
			try
			{
				await _clientRepository.SaveChangesAsync();

				return 1;
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("Произошла ошибка при сохранении", ex);
			}
		}
	}
}
