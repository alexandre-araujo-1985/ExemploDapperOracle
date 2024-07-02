using ExemploDapperOracle.Infra;
using ExemploDapperOracle.Infra.Repositories;
using ExemploDapperOracle.Domain.Contracts.Repositories;

namespace ExemploDapperOracle.DependencyInjections
{
	public static class RepositoryDependency
	{
		public static void AddClientDIRepositories(this IServiceCollection services)
		{
			services.AddTransient<IClienteRepository, ClienteRepository>();
			services.AddSingleton<DataContext>();
		}
	}
}
