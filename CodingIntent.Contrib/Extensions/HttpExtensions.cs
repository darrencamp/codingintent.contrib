using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CodingIntent.Contrib.Extensions
{
	public static class HttpExtensions
	{
		public static T Fetch<T>(this HttpClient client)
		{
			return default(T);
		}
	}
}