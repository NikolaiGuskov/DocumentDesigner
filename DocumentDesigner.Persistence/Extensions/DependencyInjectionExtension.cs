using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DocumentDesigner.Application.Data;
using DocumentDesigner.Persistence.InMemory;

namespace DocumentDesigner.Persistence.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static IServiceCollection AddPersistense(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddTransient<IClientRepository, ClientRepository>();
			services.AddTransient<IDocumentDesignerDbContext, DocumentDesignerDbContext>();

			return services;
		}
	}
}
