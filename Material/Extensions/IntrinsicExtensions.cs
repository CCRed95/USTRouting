using System;

namespace Material.Extensions
{
	public static class IntrinsicExtensions
	{
		public static T As<T>(this object @object)
		{
			if(!(@object is T))
				throw new InvalidCastException(
					$"Cannot cast object of type \'{@object.GetType().Name}\' to type \'{typeof(T).Name}\'");
			return (T) @object;
		}
	}
}
