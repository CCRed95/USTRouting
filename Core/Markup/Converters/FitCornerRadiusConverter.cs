using System.Windows;
using Core.Extensions;

namespace Core.Markup.Converters
{
	public class FitCornerRadiusConverter : XAMLConverter<double, double, NULLPARAM, CornerRadius>
	{
		public override CornerRadius Convert(double height, double width, NULLPARAM param)
		{
			var radius = height.Smallest(width) / 2;
			return new CornerRadius(radius, radius, 0, radius);
		}
	}
	public class FitCornerRadiusConverter2 : XAMLConverter<double, double, NULLPARAM, CornerRadius>
	{
		public override CornerRadius Convert(double height, double width, NULLPARAM param)
		{
			var radius = height.Smallest(width) / 2;
			return new CornerRadius(radius, radius, radius, radius);
		}
	}
}