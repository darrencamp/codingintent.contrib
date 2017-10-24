using System;
using System.Data;
using System.Threading.Tasks;

namespace CodingIntent.Contrib.Data
{
	public interface IDatabaseQuery<Connection, out TResult> where Connection : IDbConnection
	{
		TResult Execute(Connection connection);
	}
}
