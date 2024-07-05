using ExemploDapperOracle.Domain.Entities;
using ExemploDapperOracle.Domain.Contracts.Services;
using ExemploDapperOracle.Domain.Contracts.Repositories;

namespace ExemploDapperOracle.Application.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteService(IClienteRepository clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}

		public Cliente Pesquisar(int id) => _clienteRepository.Pesquisar(id);
		public IEnumerable<Cliente> ListarTodos() => _clienteRepository.ListarTodos();
		public int Incluir(Cliente cliente)
		{
			var parametros = new Dictionary<string, dynamic>
			{
				{ "id", 0 },
				{ "nome", cliente.Nome! },
				{ "data_cadastro", DateTime.Now },
				{ "data_alteracao", null! },
				{ "status", 1 }
			};

			var clienteResponse = _clienteRepository.Incluir(parametros);

			return clienteResponse;
		}

		public void Alterar(Cliente cliente)
		{
			var parametros = new Dictionary<string, dynamic>
			{
				{ "nome", cliente.Nome! },
				{ "data_alteracao", DateTime.Now }
			};

			_clienteRepository.Alterar(cliente.Id, parametros);
		}

		public void Excluir(int id) => _clienteRepository.Excluir(id);
	}
}
