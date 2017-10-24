using System;
using System.Data.SqlClient;

namespace CodingIntent.Contrib.Data.SqlServer
{
	public class SqlServerQueryExecutor : IDatabaseQueryExecutor<SqlConnection>
	{
		private readonly string _connectionString;

		public SqlServerQueryExecutor(string connectionString)
		{
			_connectionString = connectionString;
		}

		public TResult Execute<TResult>(IDatabaseQuery<SqlConnection, TResult> query)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				var result = query.Execute(connection);
				connection.Close();

				return result;
			}
		}
	}
}
