namespace Core.Markup.Converters
{
	public class MultiplyConverter : XAMLConverter<double, double, double>
	{
		public override double Convert(double value, double param)
		{
			return value * param;
		}
	}
	public class MultiplyMultiConverter : XAMLConverter<double, double, NULLPARAM, double>
	{
		public override double Convert(double value, double value2, NULLPARAM param)
		{
			return value * value2;
		}
	}
}
