using System;
using System.Data;
using System.Threading.Tasks;

namespace CodingIntent.Contrib.Data
{
	public interface IDatabaseCommand<Connection> where Connection : IDbConnection
	{
		Task<int> Execute(Connection connection);
	}
}
