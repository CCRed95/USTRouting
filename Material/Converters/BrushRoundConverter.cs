using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Core.Markup;

namespace Material.Converters
{
	public class BrushRoundConverter : XAMLConverter<SolidColorBrush, NULLPARAM, Brush>
	{
		public override Brush Convert(SolidColorBrush solidColorBrush, NULLPARAM param)
		{
			var color = solidColorBrush.Color;
			var brightness = 0.3 * color.R + 0.59 * color.G + 0.11 * color.B;
			return brightness < 123 ? Brushes.Black : Brushes.White;
		}
	}
}
