using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ExemploDapperOracle.Infra
{
	public class DataContext
	{
		public IDbConnection AbrirConexao()
		{
			var connectionString = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=xe)));User ID=system;Password=123456";
			//var connectionString = @"Driver={Oracle in OraClient11g_home1};DBQ={(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=abcd.efgh.net)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))};UID=system;PWD=Rede@!2018;";
			//var connectionString = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=host id)(PORT=specified port number)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=service name)));User Id = system; Password = Rede@!2018; ";
			//var connectionString = @"Driver={Oracle in OraClient11g_home1};Dbq=xe;Uid=system;Pwd=Rede@!2018;";

			IDbConnection dbConnection = new OracleConnection(connectionString);

			DefaultTypeMap.MatchNamesWithUnderscores = true;

			dbConnection.Open();

			return dbConnection;
		}
	}
}
