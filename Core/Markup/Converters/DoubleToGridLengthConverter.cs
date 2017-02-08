using System.Windows;

namespace Core.Markup.Converters
{
	public class DoubleToGridLengthConverter : XAMLConverter<double, NULLPARAM, GridLength>
	{
		public override GridLength Convert(double arg1, NULLPARAM param)
		{
			return new GridLength(arg1, GridUnitType.Star);
		}
	}
	public class DoubleToInvertedGridLengthConverter : XAMLConverter<double, NULLPARAM, GridLength>
	{
		public override GridLength Convert(double arg1, NULLPARAM param)
		{
			return new GridLength(1 - arg1, GridUnitType.Star);
		}
	}
	public class DoubleToGridLengthConverter2 : XAMLConverter<double, GridUnitType, GridLength>
	{
		public override GridLength Convert(double arg1, GridUnitType param)
		{
			return new GridLength(arg1, param);
		}
	}
	public class DoubleToPaddedGridLengthConverter : XAMLConverter<double, double, GridLength>
	{
		public override GridLength Convert(double arg1, double param)
		{
			return new GridLength(arg1 * param, GridUnitType.Pixel);
		}
	}
}
