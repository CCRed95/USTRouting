using System.Windows;

namespace Core.Extensions
{
	public static class ChartingExtensions
	{
		public static double Smallest(this Size i)
		{
			return i.Width < i.Height ? i.Width : i.Height;
		}
		public static double Largest(this Size i)
		{
			return i.Width > i.Height ? i.Width : i.Height;
		}
		public static Size SquareFit(this Size i)
		{
			return new Size(i.Smallest(), i.Smallest());
		}
	}
}
