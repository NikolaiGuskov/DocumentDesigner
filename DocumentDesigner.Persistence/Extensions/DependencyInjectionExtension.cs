using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DocumentDesigner.Persistence.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static IServiceCollection AddPersistense(this IServiceCollection services,
			IConfiguration configuration)
		{
			return services;
		}
	}
}
