using System.Windows;
using System.Windows.Media;
using Core.Markup;

namespace Material.Converters
{
	public class RectGeometryConverter : XAMLConverter<double, double, double, RectangleGeometry>
	{
		public override RectangleGeometry Convert(double width, double height, double corner)
		{
			return new RectangleGeometry(new Rect(0, 0, width, height))
			{
				RadiusX = corner,
				RadiusY = corner
			};
		}
	}
}
