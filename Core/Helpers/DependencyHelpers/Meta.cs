using System;
using System.Windows;

namespace Core.Helpers.DependencyHelpers
{
	//public class Meta
	//{
	//	public static Meta<D, T> CreateWithFunc<D, T>(Func<T> _defaultValueFunc,
	//		PropertyChange<D, T> changedCallback = null,
	//		PropertyCoerce<D, T> coerceCallback = null) where D : DependencyObject
	//	{
	//		return new Meta<D, T>(_defaultValueFunc, changedCallback, coerceCallback);
	//	}
	//}
	public class Meta<D, T> where D : DependencyObject
	{
		//private T defaultValue;
		//public T DefaultValue
		//{
		//	get
		//	{
		//		if (DefaultValueFunc == null)
		//			return defaultValue;

		//		var val = DefaultValueFunc.Invoke();
		//		return val;
		//	}
		//}
		public T DefaultValue { get; set; }
		//public Func<T> DefaultValueFunc { get; }
		public FrameworkPropertyMetadataOptions Flags { get; set; } = FrameworkPropertyMetadataOptions.None;
		public PropertyChange<D, T> ChangedCallback { get; }
		public PropertyCoerce<D, T> CoerceCallback { get; }

		public Meta(T _defaultValue = default(T),
			PropertyChange<D, T> changedCallback = null,
			PropertyCoerce<D, T> coerceCallback = null)
		{
			DefaultValue = _defaultValue;
			ChangedCallback = changedCallback;
			CoerceCallback = coerceCallback;
		}
		//internal Meta(Func<T> _defaultValueFunc,
		//	PropertyChange<D, T> changedCallback = null,
		//	PropertyCoerce<D, T> coerceCallback = null)
		//{
		//	DefaultValueFunc = _defaultValueFunc;
		//	ChangedCallback = changedCallback;
		//	CoerceCallback = coerceCallback;
		//}


	}
}
