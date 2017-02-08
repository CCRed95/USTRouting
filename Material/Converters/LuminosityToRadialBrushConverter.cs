using System.Windows;
using System.Windows.Media;
using Core.Markup;
using Material.Design;

namespace Material.Converters
{
	public class LuminosityToRadialBrushConverter : XAMLConverter<MaterialSet, Luminosity, NULLPARAM, Brush>
	{
		public override Brush Convert(MaterialSet materialSet, Luminosity luminosity, NULLPARAM param)
		{
			var brush = materialSet.FromLuminosity(luminosity);
			return new RadialGradientBrush
			{
				GradientOrigin = new Point(.5, .5),
				Center = new Point(.5, .5),
				GradientStops = new GradientStopCollection
				{
					new GradientStop(brush.Color, 0),
					new GradientStop(brush.Color, 0.6),
					new GradientStop(Colors.Transparent, 1)
				}
			};
		}
	}
}