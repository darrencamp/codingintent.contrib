using System;
using System.Data;
using System.Threading.Tasks;

namespace CodingIntent.Contrib.Data
{
	public interface IDatabaseCommandExecutor<Connection, Transaction> where Connection : IDbConnection where Transaction : IDbTransaction
	{
		Task<int> Execute(IDatabaseCommand<Connection> command);
		TransactionResponse Execute(ITransactionalDatabaseCommand<Connection, Transaction> command);
	}
}
