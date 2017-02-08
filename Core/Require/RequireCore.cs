using System;
using JetBrains.Annotations;

namespace Core.Require
{
	public static class RequireExtensions
	{
    public static T RequireType<T>(this object @object)
    {
			if (!(@object is T))
		    throw new InvalidCastException($"RequireType: Cannot cast object of type \'{@object.GetType().Name}\' to \'{typeof(T).Name}\'");
      return (T) @object;
    }
    public static T RequireImplement<T>(this object @object)
    {
      if (!@object.GetType().IsInstanceOfType(typeof(T)))
		    throw new Exception("RequireImplement");
	    return (T)@object;
    }
		[ContractAnnotation("notnull => halt")]
		public static void RequireNull(this object @object)
		{
			if (@object != null)
				throw new Exception("RequireNull");
		}
		[ContractAnnotation("null => halt")]
		public static object RequireNotNull(this object @object)
    {
      if (@object == null)
		    throw new Exception("RequireNotNull");
	    return @object;
    }
		[ContractAnnotation("null => halt")]
		public static T RequireNotNull<T>(this T @object)
    {
      if (@object == null)
		    throw new Exception("RequireNotNull");
	    return @object;
    }
	}
}
