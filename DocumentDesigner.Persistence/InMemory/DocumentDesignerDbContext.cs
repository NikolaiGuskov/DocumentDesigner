using DocumentDesigner.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentDesigner.Persistence.InMemory
{
	public class DocumentDesignerDbContext : IDocumentDesignerDbContext
	{
		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{
			return await Task.FromResult(1);
		}
	}
}
