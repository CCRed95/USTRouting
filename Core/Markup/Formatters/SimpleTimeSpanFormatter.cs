using System;

namespace Core.Markup.Formatters
{
	public class SimpleTimeSpanFormatter : XAMLConverter<TimeSpan?, NULLPARAM, string>
	{
		public override string Convert(TimeSpan? arg1, NULLPARAM param)
		{
			try
			{
				if (!arg1.HasValue)
					return "";

				var difference = arg1.Value;

				if (difference.Days != 0)
					return difference.ToString(@"dd\.hh\:mm\:ss");
				if (difference.Hours != 0)
					return difference.ToString(@"hh\:mm\:ss");
				if (difference.Minutes != 0)
					return difference.ToString(@"mm\:ss");
				if (difference.Seconds != 0)
					return difference.ToString(@"mm\:ss");
				return difference.ToString(@"dd\.hh\:mm\:ss");
			}
			catch
			{
				return "?";
			}
		}
	}
}
