using Dapper;
using ExemploDapperOracle.Domain.Contracts.Repositories;

namespace ExemploDapperOracle.Infra.Repositories
{
	public class RepositoryBase<T>(DataContext dataContext, string tabela) : IRepositoryBase<T> where T : class
	{
		protected readonly DataContext _dataContext = dataContext;
		private readonly string _tabela = tabela;

		public T Pesquisar(int id)
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = $"select * from {_tabela} where id = @id;";

			return conexao.QuerySingleOrDefault<T>(sql, new { id })!;
		}

		public IEnumerable<T> ListarTodos()
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = $"select * from {_tabela};";

			return conexao.Query<T>(sql);
		}
		public int Incluir(Dictionary<string, dynamic> obj)
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = @$"insert into {_tabela} 
						 values(";

			foreach (var item in obj)
			{
				if (obj.Last().Equals(item))
				{
					sql += string.Concat($"@{item.Key});");
					continue;
				}

				sql += string.Concat($"@{item.Key},");
			}

			sql += string.Concat($"SELECT CAST(SCOPE_IDENTITY() as int)");

			return conexao.ExecuteScalar<int>(sql, obj);
		}

		public void Alterar(int id, Dictionary<string, dynamic> obj)
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = @$"update {_tabela} 
						 set ";

			if (obj.Keys.Count == 1)
			{
				var item = obj.First();

				sql += string.Concat($"{item.Key} = @{item.Key}");
				sql += string.Concat("where id = @id;");

				conexao.ExecuteReader(sql, obj);
			}

			foreach (var item in obj)
			{
				if (obj.Last().Equals(item))
				{
					sql += string.Concat($"{item.Key} = @{item.Key} ");
					continue;
				}
				sql += string.Concat($"{item.Key} = @{item.Key}, ");
			}

			sql += string.Concat("where id = @id;");

			obj.Add("id", id);

			conexao.ExecuteReader(sql, obj);
		}

		public void Excluir(int id)
		{
			using var conexao = _dataContext.AbrirConexao();

			var sql = $"delete from {_tabela} where id = @id;";

			conexao.Execute(sql, new { id });
		}
	}
}
