using System;

namespace Core.Markup.Formatters
{
	public class SimpleDateTimeFormatter : XAMLConverter<DateTime, NULLPARAM, string>
	{
		public override string Convert(DateTime dateTime, NULLPARAM param)
		{
			if (dateTime == DateTime.MinValue)
			{
				return "";
			}
			if (dateTime.Date == DateTime.Today)
			{
				return dateTime.ToString("h:mm tt");
			}
			var difference = DateTime.Today.Subtract(dateTime);
			if (difference.Days < 7)
			{
				return dateTime.ToString("ddd");
			}
			return dateTime.ToString("M/d/yyyy");
		}
	}
}
