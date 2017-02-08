using System.Windows;
using System.Windows.Media;

namespace Material.Design.Text
{
	public class FlexTypeface : Typeface
		{
			public double Size { get; }
			//TODO static coerce forcecaps? for button specs
			public FlexTypeface(FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch, double fontSize) :
				base(fontFamily, fontStyle, fontWeight, fontStretch, Static.Text.Fonts.TimesNewRoman)
			{
				Size = fontSize;
			}
		}
}
