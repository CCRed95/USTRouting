using System.Windows;
using System.Windows.Media;
using Core.Helpers.DependencyHelpers;

namespace Material.Media
{
	public static class BlendedBrushAssist
	{
		public static readonly DependencyProperty BrushProperty =
			DP.Attach<BlendedBrush>(typeof(BlendedBrushAssist), new FrameworkPropertyMetadata(null, onBlendedBrushChanged));

		private static void onBlendedBrushChanged(DependencyObject i, DependencyPropertyChangedEventArgs e)
		{
			var parent = (SolidColorBrush)i;
			var blendedBrush = (BlendedBrush)e.NewValue;
			blendedBrush.Attach(parent);
		}

		public static BlendedBrush GetBrush(DependencyObject i) => i.Get<BlendedBrush>(BrushProperty);
		public static void SetBrush(DependencyObject i, BlendedBrush v) => i.Set(BrushProperty, v);
	}
}
