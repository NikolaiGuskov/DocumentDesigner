using DocumentDesigner.Application.Data;
using DocumentDesigner.Application.Handlers;
using DocumentDesigner.Application.Handlers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentDesigner.Application.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddTransient<ContextData>();
			services.AddTransient<IDocumentHandler, DocumentHandler>();

			return services;
		}
	}
}
