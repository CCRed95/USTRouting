using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Core.Helpers;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls.Behaviors
{
	//TODO make this work
	public class ListViewItemAssist
	{

		public static readonly DependencyProperty ClickSelectedToDeselectProperty =
			DP.Attach<bool>(typeof (ListViewItemAssist), new FrameworkPropertyMetadata(false, onClickSelectedToDeselectChanged));

		public static bool GetClickSelectedToDeselect(DependencyObject i) => i.Get<bool>(ClickSelectedToDeselectProperty);
		public static void SetClickSelectedToDeselect(DependencyObject i, bool v) => i.Set(ClickSelectedToDeselectProperty, v);


		private static void onClickSelectedToDeselectChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var shouldClear = e.NewValue as bool?;
			var associatedListViewItem = o as ListViewItem;

			if (!shouldClear.HasValue || !shouldClear.Value || associatedListViewItem == null)
			{
				return;
			}

			var parentListView = associatedListViewItem.FindParent<ListView>();
			parentListView.SelectionChanged += (s, args) =>
			{
				SetIsListViewItemRecentlySelected(associatedListViewItem, true);
			};
			associatedListViewItem.PreviewMouseUp += (s, args) =>
			{
				var isListViewItemRecentlySelected = GetIsListViewItemRecentlySelected(associatedListViewItem);
				if (isListViewItemRecentlySelected)
				{
					SetIsListViewItemRecentlySelected(associatedListViewItem, false);

					Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
					{
						associatedListViewItem.IsSelected = false;
					}));
				}
			};
		}



		public static readonly DependencyProperty IsListViewItemRecentlySelectedProperty =
			DP.Attach<bool>(typeof (ListViewItemAssist), new FrameworkPropertyMetadata());

		public static bool GetIsListViewItemRecentlySelected(DependencyObject i) => i.Get<bool>(IsListViewItemRecentlySelectedProperty);
		public static void SetIsListViewItemRecentlySelected(DependencyObject i, bool v) => i.Set(IsListViewItemRecentlySelectedProperty, v);

	}
}
