using System.Windows;
using Core.Extensions;

namespace Core.Markup.Converters
{
	public class FullRoundedCornerRadiusConverter : XAMLConverter<double, double, NULLPARAM, CornerRadius>
	{
		public override CornerRadius Convert(double actualWidth, double actualHeight, NULLPARAM param)
		{
			return new CornerRadius(actualWidth.Smallest(actualHeight) / 2);
		}
	}
}
