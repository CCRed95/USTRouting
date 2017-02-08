using System.Windows;
using System.Windows.Media;
using Core.Markup;

namespace Material.Markup.Converters
{
	public class BrushToRadialGradientBrushConverter : XAMLConverter<SolidColorBrush, NULLPARAM, RadialGradientBrush>
	{
		public override RadialGradientBrush Convert(SolidColorBrush arg1, NULLPARAM param)
		{
			return new RadialGradientBrush
			{
				GradientOrigin= new Point(.5, .5),
				Center = new Point(.5, .5),
				GradientStops = new GradientStopCollection
				{
					new GradientStop(arg1.Color, 0),
					new GradientStop(arg1.Color, 0.95),
					new GradientStop(Colors.Transparent, 1)
				}
			};
		}
	}
}