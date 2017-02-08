using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls.Behaviors
{
	public class ListViewAssist
	{
		public static readonly DependencyProperty DisableDragSelectProperty =
			DP.Attach<bool>(typeof(ListViewAssist), new FrameworkPropertyMetadata(false, onDisableDragSelect));

		public static bool GetDisableDragSelect(DependencyObject i) => i.Get<bool>(DisableDragSelectProperty);
		public static void SetDisableDragSelect(DependencyObject i, bool v) => i.Set(DisableDragSelectProperty, v);

		private static void onDisableDragSelect(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var value = e.NewValue as bool?;
			var associatedListBox = o as ListView;

			if (!value.HasValue || !value.Value || associatedListBox == null)
			{
				return;
			}
			associatedListBox.SelectionChanged += (s, args) =>
			{
				SetIsLeftMouseButtonPressed(associatedListBox, true);
			};
			associatedListBox.MouseUp += (s, args) =>
			{
				SetIsLeftMouseButtonPressed(associatedListBox, false);
			};
			associatedListBox.MouseMove += (s, args) =>
			{
				if (GetIsLeftMouseButtonPressed(associatedListBox))
					associatedListBox.ReleaseMouseCapture();
			};
		}


		//public static readonly DependencyProperty ClearOnMouseLeaveProperty =
		//	DP.Attach<bool>(typeof(ListViewAssist), new FrameworkPropertyMetadata(onClearOnMouseLeavePropertyChanged));

		//public static bool GetClearOnMouseLeave(DependencyObject i) => i.Get<bool>(ClearOnMouseLeaveProperty);
		//public static void SetClearOnMouseLeave(DependencyObject i, bool v) => i.Set(ClearOnMouseLeaveProperty, v);

		//private static void onClearOnMouseLeavePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		//{
		//	var value = e.NewValue as bool?;
		//	var associatedListBox = o as ListView;

		//	if (!value.HasValue || !value.Value || associatedListBox == null)
		//	{
		//		return;
		//	}
		//	associatedListBox.MouseLeave += (s, args) =>
		//																	{
		//																		associatedListBox.SelectedValue = null;
		//																	};
		//}

		public static readonly DependencyProperty IsLeftMouseButtonPressedProperty =
			DP.Attach<bool>(typeof(ListViewAssist), new FrameworkPropertyMetadata());

		public static bool GetIsLeftMouseButtonPressed(DependencyObject i) => i.Get<bool>(IsLeftMouseButtonPressedProperty);
		public static void SetIsLeftMouseButtonPressed(DependencyObject i, bool v) => i.Set(IsLeftMouseButtonPressedProperty, v);



		public static readonly DependencyProperty ClearOnSelectedProperty =
			DP.Attach<bool>(typeof(ListViewAssist), new FrameworkPropertyMetadata(false, onClearOnSelectedChanged));

		public static bool GetClearOnSelected(DependencyObject i) => i.Get<bool>(ClearOnSelectedProperty);
		public static void SetClearOnSelected(DependencyObject i, bool v) => i.Set(ClearOnSelectedProperty, v);

		private static void onClearOnSelectedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var shouldClear = e.NewValue as bool?;
			var associatedListBox = o as ListView;

			if (!shouldClear.HasValue || !shouldClear.Value || associatedListBox == null)
			{
				return;
			}
			associatedListBox.SelectionChanged += (s, args) =>
			{
				//associatedListBox.SelectedItem = null;
				var timer = new DispatcherTimer
				{
					Interval = TimeSpan.FromMilliseconds(1000)
				};
				timer.Tick += (s2, args2) =>
				{
					timer.Stop();
					Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
					{
						associatedListBox.SelectedItem = null;
					}));
				};
				timer.Start();
			};
		}




		static readonly Dictionary<ListView, Capture> Associations =
					 new Dictionary<ListView, Capture>();

		public static bool GetScrollOnNewItem(DependencyObject obj)
		{
			return (bool)obj.GetValue(ScrollOnNewItemProperty);
		}

		public static void SetScrollOnNewItem(DependencyObject obj, bool value)
		{
			obj.SetValue(ScrollOnNewItemProperty, value);
		}

		public static readonly DependencyProperty ScrollOnNewItemProperty =
				DependencyProperty.RegisterAttached(
						"ScrollOnNewItem",
						typeof(bool),
						typeof(ListViewAssist),
						new UIPropertyMetadata(false, OnScrollOnNewItemChanged));

		public static void OnScrollOnNewItemChanged(
				DependencyObject d,
				DependencyPropertyChangedEventArgs e)
		{
			var listBox = d as ListView;
			if (listBox == null) return;
			bool oldValue = (bool)e.OldValue, newValue = (bool)e.NewValue;
			if (newValue == oldValue) return;
			if (newValue)
			{
				listBox.Loaded += ListBox_Loaded;
				listBox.Unloaded += ListBox_Unloaded;
				var itemsSourcePropertyDescriptor = TypeDescriptor.GetProperties(listBox)["ItemsSource"];
				itemsSourcePropertyDescriptor.AddValueChanged(listBox, ListBox_ItemsSourceChanged);
			}
			else
			{
				listBox.Loaded -= ListBox_Loaded;
				listBox.Unloaded -= ListBox_Unloaded;
				if (Associations.ContainsKey(listBox))
					Associations[listBox].Dispose();
				var itemsSourcePropertyDescriptor = TypeDescriptor.GetProperties(listBox)["ItemsSource"];
				itemsSourcePropertyDescriptor.RemoveValueChanged(listBox, ListBox_ItemsSourceChanged);
			}
		}

		private static void ListBox_ItemsSourceChanged(object sender, EventArgs e)
		{
			var listBox = (ListView)sender;
			if (Associations.ContainsKey(listBox))
				Associations[listBox].Dispose();
			Associations[listBox] = new Capture(listBox);
		}

		static void ListBox_Unloaded(object sender, RoutedEventArgs e)
		{
			var listBox = (ListView)sender;
			if (Associations.ContainsKey(listBox))
				Associations[listBox].Dispose();
			listBox.Unloaded -= ListBox_Unloaded;
		}

		static void ListBox_Loaded(object sender, RoutedEventArgs e)
		{
			var listBox = (ListView)sender;
			var incc = listBox.Items as INotifyCollectionChanged;
			if (incc == null) return;
			listBox.Loaded -= ListBox_Loaded;
			Associations[listBox] = new Capture(listBox);
		}

		public class Capture : IDisposable
		{
			private readonly ListView listBox;
			private readonly INotifyCollectionChanged incc;

			public Capture(ListView listBox)
			{
				this.listBox = listBox;
				incc = listBox.ItemsSource as INotifyCollectionChanged;
				if (incc != null)
				{
					incc.CollectionChanged += incc_CollectionChanged;
				}
			}

			void incc_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
			{
				if (e.Action == NotifyCollectionChangedAction.Add)
				{
					listBox.ScrollIntoView(e.NewItems[0]);
					listBox.SelectedItem = e.NewItems[0];
				}
			}

			public void Dispose()
			{
				if (incc != null)
					incc.CollectionChanged -= incc_CollectionChanged;
			}
		}
	}
}
