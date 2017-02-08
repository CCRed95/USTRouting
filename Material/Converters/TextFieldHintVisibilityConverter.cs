using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Core.Markup;

namespace Material.Converters
{
	public class TextFieldHintVisibilityConverter : XAMLConverter<object, NULLPARAM, Visibility>
	{
		public override Visibility Convert(object value, NULLPARAM param)
		{
			return string.IsNullOrEmpty((value ?? "").ToString()) ? Visibility.Visible : Visibility.Hidden;
		}
	}
}
