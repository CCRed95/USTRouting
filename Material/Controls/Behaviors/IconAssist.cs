using System.Windows;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls.Behaviors
{
	public static class IconAssist
	{
		public static readonly DependencyProperty ScaleProperty =
			DP.Attach<double>(typeof (IconAssist), new FrameworkPropertyMetadata(1d));

		public static double GetScale(DependencyObject i) => i.Get<double>(ScaleProperty);
		public static void SetScale(DependencyObject i, double v) => i.Set(ScaleProperty, v);


		public static readonly DependencyProperty RotationProperty =
			DP.Attach<double>(typeof (IconAssist), new FrameworkPropertyMetadata(0d));

		public static double GetRotation(DependencyObject i) => i.Get<double>(RotationProperty);
		public static void SetRotation(DependencyObject i, double v) => i.Set(RotationProperty, v);

	}
}
 