using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CodingIntent.Contrib.Data.SqlServer
{
	public class SqlServerCommandExecutor : IDatabaseCommandExecutor<SqlConnection, SqlTransaction>, IDisposable
	{
		private readonly string _sqlServerConnectionString;

		private SqlConnection _sqlConnection;
		private SqlTransaction _sqlTransaction;

		public SqlServerCommandExecutor(string sqlServerConnectionString)
		{
			_sqlServerConnectionString = sqlServerConnectionString;
		}

		public Task<int> Execute(IDatabaseCommand<SqlConnection> command)
		{
			using (var connection = new SqlConnection(_sqlServerConnectionString))
			{
				connection.Open();
				var result = command.Execute(connection);
				connection.Close();

				return result;
			}
		}

		public TransactionResponse Execute(ITransactionalDatabaseCommand<SqlConnection, SqlTransaction> command)
		{
			if (_sqlConnection == null)
			{
				_sqlConnection = new SqlConnection(_sqlServerConnectionString);
				_sqlConnection.Open();
				_sqlTransaction = _sqlConnection.BeginTransaction();
			}

			var result = command.Execute(_sqlConnection, _sqlTransaction);

			return new TransactionResponse { Transaction = _sqlTransaction, Result = result };
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_sqlConnection != null)
				{
					_sqlConnection.Close();
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
