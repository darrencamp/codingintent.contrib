using System;

namespace CodingIntent.Contrib
{
    public static class StringExtensions
    {
		public static string[] SplitOnNewLine(this string source)
		{
			return source.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
		}
	}
}
