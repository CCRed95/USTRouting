using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Core.Stylization
{
	[TypeConverter(typeof(TextStyleStackConverter))]
	public class TextStyleStack
	{
		public double? FontSize { get; set; }
		public FontWeight? FontWeight { get; set; }
		public FontFamily FontFamily { get; set; }
		public Brush Foreground { get; set; }
		public Brush Background { get; set; }
		private static FontSizeConverter fsc = new FontSizeConverter();

		public static TextStyleStack Parse(string stack)
		{
			var value =  new TextStyleStack();
			var stackMembers = stack.Split(' ');
			foreach (var stackMember in stackMembers)
			{
				if (stackMember.ToLower() == "bold")
				{
					value.FontWeight = FontWeights.Bold;
				}
				if (stackMember.EndsWith("pt"))
				{
					value.FontSize = (double)fsc.ConvertFromString(stackMember);
				}
			}
			return value;
		}

		public static bool IsValidFormat(string stack)
		{
			return true;
		}
	}
}
