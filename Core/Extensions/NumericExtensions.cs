using System;

namespace Core.Extensions
{
	public static class NumericExtensions
	{
		public static double Smallest(this double a, double b) => a < b ? a : b;
		public static int Smallest(this int a, int b) => a < b ? a : b;

		public static double Largest(this double a, double b) => a > b ? a : b;
		public static int Largest(this int a, int b) => a > b ? a : b;

		public static double Map(this double i, double initialMin, double initialMax, double targetMin, double targetMax)
		{
			var effectiveRange = initialMax - initialMin;
			var effectiveInitialValue = i - initialMin;
			var initialProgression = effectiveInitialValue / effectiveRange;

			var targetRange = targetMax - targetMin;
			var targetProgression = targetRange * initialProgression;

			var finalValue = targetProgression + targetMin;
			return finalValue;
		}
		public static long Map(this double i, double initialMin, double initialMax, long targetMin, long targetMax)
		{
			var effectiveRange = initialMax - initialMin;
			var effectiveInitialValue = i - initialMin;
			var initialProgression = effectiveInitialValue / effectiveRange;

			var targetRange = targetMax - targetMin;
			var targetProgression = targetRange * initialProgression;

			var finalValue = targetProgression + targetMin;
			return Convert.ToInt64(finalValue);
		}
		public static double Map(this long i, long initialMin, long initialMax, double targetMin, double targetMax)
		{
			var effectiveRange = initialMax - initialMin;
			var effectiveInitialValue = i - initialMin;
			var initialProgression = effectiveInitialValue / effectiveRange;

			var targetRange = targetMax - targetMin;
			var targetProgression = targetRange * initialProgression;

			var finalValue = targetProgression + targetMin;
			return finalValue;
		}

		public static double MinAllocTarget(this double i, double? targetline)
		{
			if (targetline.HasValue)
				return i.Smallest(targetline.Value);
			return i;
		}
		public static double MaxAllocTarget(this double i, double? targetline)
		{
			if (targetline.HasValue)
				return i.Largest(targetline.Value);
			return i;
		}
		public static int RollRange(this int i, int rangelow, int rangehigh)
		{
			if (i < rangelow)
			{
				var difference = rangelow - i;
				return rangehigh - difference + 1;
			}
			if (i > rangehigh)
			{
				var difference = i - rangehigh;
				return rangelow + difference - 1;
			}
			return i;
		}

		public static double Map(this DateTime i, DateTime initialMin, DateTime initialMax, double targetMin, double targetMax)
		{
			var effectiveTimeRange = initialMax - initialMin;
			var effectiveInitialValue = i - initialMin;
			var initialProgression = effectiveInitialValue.DividedBy(effectiveTimeRange);

			var targetRange = targetMax - targetMin;
			var targetProgression = targetRange * initialProgression;

			var finalValue = targetProgression + targetMin;
			return finalValue;
		}

		public static string FixedDigit(this int i, int digits)
		{
			return i.ToString().PadLeft(digits, '0');
		}
		public static TimeSpan MultipliedBy(this TimeSpan i, int x)
		{
			return TimeSpan.FromTicks(i.Ticks * x);
		}
		public static TimeSpan DividedBy(this TimeSpan i, int x)
		{
			return TimeSpan.FromTicks(i.Ticks / x);
		}
		public static double DividedBy(this TimeSpan i, TimeSpan x)
		{
			return (double)i.Ticks / x.Ticks;
		}

		public static double Squared(this double i)
		{
			return Math.Pow(i, 2);
		}
		public static double Power(this double i, int ex)
		{
			return Math.Pow(i, ex);
		}
		public static double Root(this double i)
		{
			return Math.Sqrt(i);
		}

		public static double Round(this double i, int decimals = 0, MidpointRounding mr = MidpointRounding.ToEven)
		{
			return Math.Round(i, decimals, mr);
		}
		public static double ToValidLength(this double i)
		{
			return i < 0 ? 0 : i;
		}
		public static int ToInt(this double i)
		{
			return Convert.ToInt32(i);
		}
		
	}
}
