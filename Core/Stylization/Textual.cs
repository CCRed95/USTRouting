using System.Windows;
using System.Windows.Controls;
using Core.Helpers.DependencyHelpers;

namespace Core.Stylization
{
	public static class Textual
	{
		public static readonly DependencyProperty StyleStackProperty =
			DP.Attach<TextStyleStack>(typeof(Textual), new FrameworkPropertyMetadata(null, onStyleStackChanged));

		public static TextStyleStack GetStyleStack(DependencyObject i) => i.Get<TextStyleStack>(StyleStackProperty);
		public static void SetStyleStack(DependencyObject i, TextStyleStack v) => i.Set(StyleStackProperty, v);

		private static void onStyleStackChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var textStyleStack = e.NewValue as TextStyleStack;
			var textElement = o as Label;
			if (textStyleStack != null && textElement != null)
			{
				textElement.Foreground = textStyleStack.Foreground;
				if (textStyleStack.FontSize.HasValue)
					textElement.FontSize = textStyleStack.FontSize.Value;
				if (textStyleStack.FontWeight != null)
					textElement.FontWeight = textStyleStack.FontWeight.Value;
			}
		}


	}
}
