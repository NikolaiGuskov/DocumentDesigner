using DocumentDesigner.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentDesigner.Persistence
{
	public class DocumentDesignerDbContext : IDocumentDesignerDbContext
	{
		public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}
