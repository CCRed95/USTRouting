using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Animation;

namespace Core.Extensions
{
	public enum TOD
	{
		AM,
		PM
	}
	public static class TimeExtensions
	{
		public static Duration MillisecondsD(this int i)
		{
			return new Duration(TimeSpan.FromMilliseconds(i));
		}
		public static Duration MillisecondsD(this double i)
		{
			return new Duration(TimeSpan.FromMilliseconds(i));
		}

		public static TimeSpan MillisecondsT(this int i)
		{
			return TimeSpan.FromMilliseconds(i);
		}
		public static TimeSpan MillisecondsT(this double i)
		{
			return TimeSpan.FromMilliseconds(i);
		}

		public static KeyTime MillisecondsK(this int i)
		{
			return KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(i));
		}
		public static KeyTime MillisecondsK(this double i)
		{
			return KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(i));
		}

		public static DateTime AtTime(this DateTime @this, int hours, int minutes, TOD timeOfDay)
		{
			if (timeOfDay == TOD.PM)
				hours += 12;

			return @this.Add(new TimeSpan(hours, minutes, 0));
		}
		public static DateTime AtTime(this DateTime @this, string time)
		{
			var matches = Regex.Matches(time, "([0-9]*) ?: ?([0-9]*) ?([A?P?]M)").Cast<Match>().ToArray()[0].Groups;
			if(matches.Count != 4)
				throw new FormatException();
			var hours = matches[1].Value.To<int>();
			var minutes = matches[2].Value.To<int>();
			var isPM = matches[3].Value.Trim().ToUpper() == "PM";
			if (isPM)
				hours += 12;

			return @this.Add(new TimeSpan(hours, minutes, 0));

		}
}
}