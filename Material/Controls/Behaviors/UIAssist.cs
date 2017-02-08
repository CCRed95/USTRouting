using System;
using System.Windows;
using Core.Helpers.DependencyHelpers;
using Core.Helpers.EventHelpers;

namespace Material.Controls.Behaviors
{
	//TODO why doesnt this work?
	public static class UIAssist
	{
		public static readonly DependencyProperty CollapseIfDisabledProperty =
			DP.Attach<bool>(typeof(UIAssist), new FrameworkPropertyMetadata(false, onCollapseIfDisabledChanged));

		public static bool GetCollapseIfDisabled(DependencyObject i) => i.Get<bool>(CollapseIfDisabledProperty);
		public static void SetCollapseIfDisabled(DependencyObject i, bool v) => i.Set(CollapseIfDisabledProperty, v);

		private static void onCollapseIfDisabledChanged(DependencyObject i, DependencyPropertyChangedEventArgs e)
		{
			var uiElement = i as UIElement;
			var value = e.NewValue as bool?;
			if (uiElement != null && value.HasValue && value.Value)
			{
				if (uiElement.IsEnabled)
				{
					uiElement.Visibility = Visibility.Collapsed;
				}
				uiElement.IsEnabledChanged += (s, args) =>
				{
					var senderElement = s as UIElement;
					var isEnabled = e.NewValue as bool?;
					if (senderElement != null && isEnabled.HasValue)
					{
						senderElement.Visibility = isEnabled.Value ? Visibility.Visible : Visibility.Collapsed;
					}

				};
			}
		}



		public static readonly DependencyProperty IsVisibleInViewportProperty =
			DP.Attach<bool>(typeof(UIAssist), new FrameworkPropertyMetadata(false, onIsVisibleInViewportChanged));
		
		private static void onIsVisibleInViewportChanged(DependencyObject i, DependencyPropertyChangedEventArgs e)
		{
			var uiElement = i as UIElement;
			var value = e.NewValue as bool?;
			if (uiElement != null && value.HasValue && value.Value)
			{
				
				uiElement.IsEnabledChanged += (s, args) =>
				{
					var senderElement = s as UIElement;
					var isEnabled = e.NewValue as bool?;
					if (senderElement != null && isEnabled.HasValue)
					{
						senderElement.Visibility = isEnabled.Value ? Visibility.Visible : Visibility.Collapsed;
					}

				};
			}
		}

		public static bool GetIsVisibleInViewport(DependencyObject i) => i.Get<bool>(IsVisibleInViewportProperty);
		public static void SetIsVisibleInViewport(DependencyObject i, bool v) => i.Set(IsVisibleInViewportProperty, v);


	}
}
