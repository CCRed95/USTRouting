using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace Core.Markup.Extensions
{
	public class RGBExtension : MarkupExtension
	{
		protected byte R { get; set; }
		protected byte G { get; set; }
		protected byte B { get; set; }

		public RGBExtension(byte r, byte g, byte b)
		{
			R = r;
			G = g;
			B = b;
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return Color.FromRgb(R, G, B);
		}
	}
}
