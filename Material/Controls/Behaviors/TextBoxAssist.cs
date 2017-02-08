using System.Windows;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls.Behaviors
{
	public static class TextBoxAssist
	{
		public static readonly DependencyProperty ForceImmediateUpdateBindingProperty =
			DP.Attach<bool>(typeof(TextBoxAssist), new FrameworkPropertyMetadata(PropertyChangedCallback));

		private static void PropertyChangedCallback(DependencyObject i, DependencyPropertyChangedEventArgs e)
		{

			
		}

		public static bool GetForceImmediateUpdateBinding(DependencyObject i) => i.Get<bool>(ForceImmediateUpdateBindingProperty);
		public static void SetForceImmediateUpdateBinding(DependencyObject i, bool v) => i.Set(ForceImmediateUpdateBindingProperty, v);
	}
}
