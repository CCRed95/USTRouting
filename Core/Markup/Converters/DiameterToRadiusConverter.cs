namespace Core.Markup.Converters
{
	public class DiameterToRadiusConverter : XAMLConverter<double, NULLPARAM, double>
	{
		public override double Convert(double diameter, NULLPARAM param)
		{
			return diameter / 2;
		}
	}
}
