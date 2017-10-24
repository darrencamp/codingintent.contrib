using System;
using System.Data;

namespace CodingIntent.Contrib.Data
{
	public interface IDatabaseQueryExecutor<Connection> where Connection : IDbConnection
	{
		TResult Execute<TResult>(IDatabaseQuery<Connection, TResult> query);
	}
}
