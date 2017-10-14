using System;

namespace CodingIntent.Contrib.Extensions
{
    public static class StringExtensions
    {
		public static string[] SplitOnNewLine(this string source)
		{
			return source.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
		}
	}
}
