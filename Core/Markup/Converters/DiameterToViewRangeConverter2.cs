using System.Windows;

namespace Core.Markup.Converters
{
	public class DiameterToViewRangeConverter2 : XAMLConverter<double, NULLPARAM, Rect>
	{
		public override Rect Convert(double diameter, NULLPARAM param)
		{
			return new Rect(new Size(diameter, diameter));
		}
	}
}
