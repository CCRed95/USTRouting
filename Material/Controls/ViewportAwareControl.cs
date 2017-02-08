using System.Windows;
using System.Windows.Controls;
using Core.Controls;
using Core.Helpers.EventHelpers;

namespace Material.Controls
{
	public class ViewportAwareControl : FlexControl
	{
		public static readonly RoutedEvent EnteringViewEvent = EM.Register<ViewportAwareControl, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler EnteringView
		{
			add { AddHandler(EnteringViewEvent, value); }
			remove { RemoveHandler(EnteringViewEvent, value); }
		}

		public static readonly RoutedEvent ExitingViewEvent = EM.Register<ViewportAwareControl, RoutedEventHandler>(EM.BUBBLE);

		public event RoutedEventHandler ExitingView
		{
			add { AddHandler(ExitingViewEvent, value); }
			remove { RemoveHandler(ExitingViewEvent, value); }
		}
		protected static RoutedEvent ListViewEnteringViewEvent = EnteringViewEvent.AddOwner(typeof(ListView));
		protected static RoutedEvent ListViewExitingViewEvent = ExitingViewEvent.AddOwner(typeof(ListView));

		public ViewportAwareControl()
		{
	
		}


	}
}
