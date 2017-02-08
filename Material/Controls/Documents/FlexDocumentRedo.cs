using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls.Documents
{
	[ContentProperty("Tabs")]
	public class FlexDocumentRedo : FrameworkElement
	{
		public static readonly DependencyProperty TabsProperty = DP.Register(
			new Meta<FlexDocumentRedo, ObservableCollection<FlexDocumentTabRedo>>());

		public ObservableCollection<FlexDocumentTabRedo> Tabs
		{
			get { return (ObservableCollection<FlexDocumentTabRedo>) GetValue(TabsProperty); }
			set { SetValue(TabsProperty, value); }
		}

		public FlexDocumentRedo()
		{
			Tabs = new ObservableCollection<FlexDocumentTabRedo>();
		}
	}
}
