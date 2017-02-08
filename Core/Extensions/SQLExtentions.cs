using System;
using System.Data;

namespace Core.Extensions
{
	public static class SQLExtentions
	{
		public static T Get<T>(this IDataRecord reader, string name, Func<object, T> conversion, bool allowNull = true)
		{
			var data = reader[name];
			if (!allowNull)
				return conversion(data);
			if (data == null || data is DBNull)
				return default(T);
			return conversion(data);
		}
	}
}
