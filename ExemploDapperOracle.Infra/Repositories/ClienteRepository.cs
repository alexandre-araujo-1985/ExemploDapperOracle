using ExemploDapperOracle.Domain.Entities;
using ExemploDapperOracle.Domain.Contracts.Repositories;
using ExemploDapperOracle.Domain.Constants;

namespace ExemploDapperOracle.Infra.Repositories
{
	public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
	{
		public ClienteRepository(DataContext dataContext) : base(dataContext, TabelaConstant.TabelaCliente)
		{
		}
	}
}
