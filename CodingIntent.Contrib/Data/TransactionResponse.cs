using System;
using System.Data;

namespace CodingIntent.Contrib.Data
{
	public class TransactionResponse
	{
		public IDbTransaction Transaction { get; set; }
		public int Result { get; set; }
	}
}
