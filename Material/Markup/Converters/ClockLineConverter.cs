using System;
using System.Globalization;
using System.Windows.Data;
using Core.Markup;
using Material.Controls;

namespace Material.Markup.Converters
{
	public class ClockLineConverter : XAMLConverter<DateTime, ClockDisplayMode, int>
	{
		public override int Convert(DateTime value, ClockDisplayMode param)
		{
			return param == ClockDisplayMode.Hours
						? (value.Hour > 13 ? value.Hour - 12 : value.Hour) * (360 / 12)
						: (value.Minute == 0 ? 60 : value.Minute) * (360 / 60);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}