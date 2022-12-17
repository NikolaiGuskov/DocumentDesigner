using DocumentDesigner.Application.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentDesigner.Application.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static IServiceCollection AddPersistense(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddTransient<ContextData>();

			return services;
		}
	}
}
