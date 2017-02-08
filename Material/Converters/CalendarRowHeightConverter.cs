using Core.Markup;

namespace Material.Converters
{
	public class CalendarRowHeightConverter : XAMLConverter<double, int, double>
	{
		public override double Convert(double actualWidth, int rows)
		{
			var columnWidth = actualWidth / 7;
			return rows*columnWidth;
		}
	}
}
