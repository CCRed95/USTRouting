using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Core.Markup.Converters
{
	public class InvertableBoolToVisibilityConverter : XAMLConverter<Boolean, Boolean, Visibility>
	{
		private static BooleanToVisibilityConverter msConverter = new BooleanToVisibilityConverter();

		public override Visibility Convert(bool arg1, bool param)
		{
			return (Visibility)msConverter.Convert(param ? !arg1 : arg1, typeof (Visibility), null, CultureInfo.CurrentCulture);
		}
	}
}
