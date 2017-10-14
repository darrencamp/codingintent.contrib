using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodingIntent.Contrib.Extensions
{
	public static class HttpExtensions
	{
		public static async Task<T> Post<T>(this HttpClient http, string action, object data)
		{
			var jsonContent = JsonConvert.SerializeObject(data);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
			var response = await http.PostAsync(action, content);
			if (response.IsSuccessStatusCode)
			{
				var jsonResponse = await response.Content.ReadAsStringAsync();
				var typedResponse = JsonConvert.DeserializeObject<T>(jsonResponse);
				return typedResponse;
			}
			else
			{
				throw new HttpRequestException($"{response.ReasonPhrase} ({response.StatusCode})");
			}

		}
	}
}