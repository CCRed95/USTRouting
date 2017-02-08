namespace Core.Markup.Converters
{
	public class AddConverter : XAMLConverter<double, double, NULLPARAM, double>
	{
		public override double Convert(double value, double value2, NULLPARAM param)
		{
			return value + value2;
		}
	}
}
