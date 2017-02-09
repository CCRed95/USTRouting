using System;

namespace Core.Extensions
{
	public static class TypeExtensions
	{
		public static T As<T>(this object @object)
		{
			if(!(@object is T))
				throw new InvalidCastException(
					$"Cannot cast object of type \'{@object.GetType().Name}\' to type \'{typeof(T).Name}\'");
			return (T) @object;
		}
		public static T To<T>(this object @object)
		{
			return Convert.ChangeType(@object, typeof(T)).As<T>();
		}
	}
}
