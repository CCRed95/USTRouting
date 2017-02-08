using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Core.Extensions
{
	public static class RenderingExtensions
	{
		// TODO pass string content for all these. or else size.width means nothing
		public static Size EstimateLabelRenderSize(FontFamily fontFamily, double fontSize, string content = "Fq")
		{
			var defaultPadding = new Thickness(5);
			return EstimateTextRenderSize(fontFamily, fontSize, defaultPadding, content);
		}
		public static Size EstimateLabelRenderSize(FontFamily fontFamily, double fontSize, Thickness padding, string content = "Fq")
		{
			return EstimateTextRenderSize(fontFamily, fontSize, padding, content);
		}
		public static Size EstimateTextRenderSize(FontFamily fontFamily, double fontSize, string content = "Fq")
		{
			return EstimateTextRenderSize(fontFamily, fontSize, new Thickness(0), content);
		}
		public static Size EstimateTextRenderSize(FontFamily fontFamily, double fontSize, Thickness padding, string content = "Fq")
		{
			var formattedText = new FormattedText(content, CultureInfo.GetCultureInfo("en-us"),
						FlowDirection.LeftToRight, new Typeface(fontFamily.ToString()), fontSize, Brushes.Black);
			return new Size(formattedText.Width + padding.Left + padding.Right, formattedText.Height + padding.Top + padding.Bottom);
		}

		public static System.Drawing.Point ToD_POINT(this Point i)
		{
			return new System.Drawing.Point(i.X.ToInt(), i.Y.ToInt());
		}
		public static Point ToW_POINT(this System.Drawing.Point i)
		{
			return new Point(i.X, i.Y);
		}

		public static System.Drawing.Size ToD_SIZE(this Size i)
		{
			return new System.Drawing.Size(i.Width.ToInt(), i.Height.ToInt());
		}
		public static Size ToW_SIZE(this System.Drawing.Size i)
		{
			return new Size(i.Width, i.Height);
		}
		public static System.Drawing.Point TopLeft(this System.Drawing.Rectangle i)
		{
			return new System.Drawing.Point(i.X, i.Y);
		}





	}
}
