using System.Collections.Generic;

namespace UST_Routing.Extensions
{
	public static class LinqExtensions
	{
		public static List<T> AsList<T>(this T i)
		{
			return new List<T> { i };
		}
	}
}
