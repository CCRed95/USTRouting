using System.Windows;
using System.Windows.Media;
using Core.Markup;

namespace Material.Converters
{
	public class EllipseGeometryConverter : XAMLConverter<double, double, NULLPARAM, EllipseGeometry>
	{
		public override EllipseGeometry Convert(double width, double height, NULLPARAM param)
		{//new Rect(0, 0, width, height)
			return new EllipseGeometry
			{
				RadiusX = width / 2,
				RadiusY = height / 2,
				Center = new Point(width / 2, height / 2)
			};
		}
	}
}