using System.Windows;
using System.Windows.Controls;

namespace Core.Extensions
{
	public static class ControlExtensions
	{
		public static Size CalculateUsableSize(this Control i)
		{
			var activeGraphWidth = i.ActualWidth - i.Padding.Left - i.Padding.Right;
			var activeGraphHeight = i.ActualHeight - i.Padding.Left - i.Padding.Right;
			return new Size(activeGraphWidth, activeGraphHeight);
		}
		public static Size CalculateTotalSize(this FrameworkElement i)
		{
			return new Size(i.ActualWidth, i.ActualHeight);
		}
		
		public static void DockLeft(this UIElement i)
		{
			DockPanel.SetDock(i, Dock.Left);
		}
		public static void DockTop(this UIElement i)
		{
			DockPanel.SetDock(i, Dock.Top);
		}
		public static void DockRight(this UIElement i)
		{
			DockPanel.SetDock(i, Dock.Right);
		}
		public static void DockBottom(this UIElement i)
		{
			DockPanel.SetDock(i, Dock.Bottom);
		}

		public static void GoToVisualState(this FrameworkElement i, string state, bool withTransitions = true)
		{
			VisualStateManager.GoToState(i, state, withTransitions);
		}

	}
}
