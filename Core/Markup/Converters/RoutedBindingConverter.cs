using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Core.Helpers.DependencyHelpers;

namespace Core.Markup.Converters
{
	public class RoutedBindingConverter : DependencyObject, IValueConverter//: XAMLConverter<string, NULLPARAM, BindingExpressionBase>
	{
		//public static readonly DependencyProperty BindingExpressionProperty = DP.Register(
		//	new Meta<RoutedBindingConverter, BindingExpressionBase>());
		//public BindingExpressionBase BindingExpression
		//{
		//	get { return (BindingExpressionBase)GetValue(BindingExpressionProperty); }
		//	set { SetValue(BindingExpressionProperty, value); }
		//}
		//public static readonly DependencyProperty FrameworkElementProperty = DP.Register(
		//	new Meta<RoutedBindingConverter, FrameworkElement>());
		//public FrameworkElement FrameworkElement
		//{
		//	get { return (FrameworkElement) GetValue(FrameworkElementProperty); }
		//	set { SetValue(FrameworkElementProperty, value); }
		//}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var frameworkElement = value as FrameworkElement;
			if (frameworkElement == null)
				throw new Exception("frameworkelement null");

			var parameterStr = parameter.ToString();
			var element = frameworkElement.FindName(parameterStr);

			return element;

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		//public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		//{
		//	var 
		//}

		//public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
