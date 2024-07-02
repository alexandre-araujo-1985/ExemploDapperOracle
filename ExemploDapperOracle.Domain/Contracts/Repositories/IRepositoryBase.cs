namespace ExemploDapperOracle.Domain.Contracts.Repositories
{
	public interface IRepositoryBase<T> where T : class
	{
		T Pesquisar(int id);
		int Incluir(Dictionary<string, dynamic> obj);
		void Alterar(int id, Dictionary<string, dynamic> obj);
		IEnumerable<T> ListarTodos();
		void Excluir(int id);
	}
}
