using ExemploDapperOracle.Application.Services;
using ExemploDapperOracle.Domain.Contracts.Services;

namespace ExemploDapperOracle.DependencyInjections
{
	public static class ServiceDependency
	{
		public static void AddClientDIServices(this IServiceCollection services)
		{
			services.AddTransient<IClienteService, ClienteService>();
		}
	}
}
