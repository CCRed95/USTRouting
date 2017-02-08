using System;
using System.Windows.Markup;
using System.Windows.Media;

namespace Core.Markup.Extensions
{
	public class GreyExtension : MarkupExtension
	{
		protected byte Value { get; set; }
		protected byte A { get; set; } = 255;

		public GreyExtension(byte value)
		{
			Value = value;
		}
		public GreyExtension(object value)
		{
			Value = Convert.ToByte(value);
		}
		public GreyExtension(byte value, byte a)
		{
			Value = value;
			A = a;
		}
		public GreyExtension(object value, object a)
		{
			Value = Convert.ToByte(value);
			A = Convert.ToByte(a);
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return Color.FromArgb(A, Value, Value, Value);
		}
	}
}