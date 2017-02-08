using System.Windows;
using Core.Markup;

namespace Material.Converters
{
	public class WidthToCenterPointConverter : XAMLConverter<double, NULLPARAM, Point>
	{
		public override Point Convert(double width, NULLPARAM param)
		{
			return new Point(width, 0);
		}
	}
}
