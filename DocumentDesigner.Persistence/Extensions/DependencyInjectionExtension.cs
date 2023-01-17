using Microsoft.Extensions.DependencyInjection;
using DocumentDesigner.Application.Data;
using DocumentDesigner.Persistence.Data;
using DocumentDesigner.Persistence.Data.Repository;

namespace DocumentDesigner.Persistence.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static IServiceCollection AddPersistense(this IServiceCollection services)
		{
			services.AddTransient<IClientRepository, ClientRepository>();
			services.AddTransient<IDocumentRepository, DocumentRepository>();
			services.AddDbContext<DocumentDisegnerContext>();

			return services;
		}
	}
}
