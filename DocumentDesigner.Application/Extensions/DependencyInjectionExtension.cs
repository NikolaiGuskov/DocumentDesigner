using DocumentDesigner.Application.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentDesigner.Application.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddTransient<ContextData>();

			return services;
		}
	}
}
