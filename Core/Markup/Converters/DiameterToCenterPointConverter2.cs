using System.Windows;

namespace Core.Markup.Converters
{
	public class DiameterToCenterPointConverter2 : XAMLConverter<double, NULLPARAM, Point>
	{
		public override Point Convert(double diameter, NULLPARAM param)
		{
			var radius = diameter / 2;
			return new Point(radius, radius);
		}
	}
}
