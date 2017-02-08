using Core.Extensions;
using Core.Markup;

namespace Material.Converters
{
	public class WaveRevealTransitionMaskRadiusConverter : XAMLConverter<double, double, NULLPARAM, double>
	{
		public override double Convert(double width, double height, NULLPARAM param)
		{
			var hypotenuse = (width.Squared() + height.Squared()).Root();
			return hypotenuse * .7;
		}
	}
}
