using System;
using System.Windows;
using System.Windows.Controls;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls.Behaviors
{
	public enum TabIndex
	{
		Unselected,
		LeftOfSelected,
		Selected,
		RightOfSelected
	}
	public static class TabControlAssist
	{
		public static readonly DependencyProperty TabIndexProperty =
			DP.Attach<TabIndex>(typeof(TabControlAssist), new FrameworkPropertyMetadata());

		public static TabIndex GetTabIndex(DependencyObject i) => i.Get<TabIndex>(TabIndexProperty);
		public static void SetTabIndex(DependencyObject i, TabIndex v) => i.Set(TabIndexProperty, v);

		public static readonly DependencyProperty IndexTabPositionProperty =
			DP.Attach<bool>(typeof(TabControlAssist), new FrameworkPropertyMetadata(false, onIndexTabPositionChanged));

		private static void onIndexTabPositionChanged(DependencyObject i, DependencyPropertyChangedEventArgs e)
		{
			var tabControl = i as TabControl;
			if (tabControl == null)
				return;

			var value = e.NewValue as bool?;
			if (!value.HasValue)
				return;

			if (value.Value)
			{
				tabControl.SelectionChanged += (s, args) =>
																			 {
																				 var selectedIndex = tabControl.SelectedIndex;
																				 var tabHost = (Panel)tabControl.Template.FindName("PART_TabHost", tabControl);

																				 var index = 0;
																				 foreach (var child in tabHost.Children)
																				 {
																					 var tabItem = child as TabItem;
																					 if (tabItem == null)
																						 continue;

																					 if (index == selectedIndex)
																					 {
																						 SetTabIndex(tabItem, TabIndex.Selected);
																					 }
																					 else if (index == selectedIndex - 1)
																					 {
																						 SetTabIndex(tabItem, TabIndex.LeftOfSelected);
																					 }
																					 else if (index == selectedIndex + 1)
																					 {
																						 SetTabIndex(tabItem, TabIndex.RightOfSelected);
																					 }
																					 else
																					 {
																						 SetTabIndex(tabItem, TabIndex.Unselected);
																					 }
																					 index++;
																				 }
																			 };
			}
			else
			{


			}

		}

		public static bool GetIndexTabPosition(DependencyObject i) => i.Get<bool>(IndexTabPositionProperty);
		public static void SetIndexTabPosition(DependencyObject i, bool v) => i.Set(IndexTabPositionProperty, v);


	}
}
