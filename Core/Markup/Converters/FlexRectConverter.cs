using System.Windows;

namespace Core.Markup.Converters
{
	public class FlexRectConverter : XAMLConverter<double, double, NULLPARAM, Rect>
	{
		public override Rect Convert(double width, double height, NULLPARAM param)
		{
			return new Rect(new Point(0, 0), new Size(width, height));
		}
	}
}
