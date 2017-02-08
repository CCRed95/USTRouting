using System;

namespace Core.Markup.Converters
{
	public class DateDifferenceConverter : XAMLConverter<DateTime, DateTime, NULLPARAM, string>
	{
		protected override DateTime ConvertArg2(object arg)
		{
			try
			{
				return base.ConvertArg2(arg);
			}
			catch
			{
				return DateTime.MinValue;
			}

		}

		public override string Convert(DateTime start, DateTime end, NULLPARAM param)
		{
			try
			{
				if (end == DateTime.MinValue)
					return "";
				var difference = end - start;

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
