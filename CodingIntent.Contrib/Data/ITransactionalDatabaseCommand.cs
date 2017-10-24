using System;
using System.Data;

namespace CodingIntent.Contrib.Data
{
	public interface ITransactionalDatabaseCommand<Connection, Transaction> where Connection : IDbConnection where Transaction : IDbTransaction
	{
		int Execute(Connection connection, Transaction transaction);
	}
}
