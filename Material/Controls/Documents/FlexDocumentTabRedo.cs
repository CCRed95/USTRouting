using System.Windows;
using System.Windows.Controls;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls.Documents
{
	public class FlexDocumentTabRedo : ContentControl
	{
		public static readonly DependencyProperty TitleProperty = DP.Register(
			new Meta<FlexDocumentTabRedo, string>("Title"));
				
		public static readonly DependencyProperty MinimumSupportedVersionProperty = DP.Register(
			new Meta<FlexDocumentTabRedo, string>("0.0.0.0"));

		public static readonly DependencyProperty RenderWidthProperty = DP.Register(
			new Meta<FlexDocumentTabRedo, double>(2000));

		public static readonly DependencyProperty RenderHeightProperty = DP.Register(
			new Meta<FlexDocumentTabRedo, double>(2600));

		//public static readonly DependencyProperty BackgroundProperty = DP.Register(
		//	new Meta<FlexDocumentTabRedo, Brush>());
		//public Brush Background
		//{
		//	get { return (Brush) GetValue(BackgroundProperty); }
		//	set { SetValue(BackgroundProperty, value); }
		//}
		

		public string Title
		{
			get { return (string) GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		public string MinimumSupportedVersion
		{
			get { return (string) GetValue(MinimumSupportedVersionProperty); }
			set { SetValue(MinimumSupportedVersionProperty, value); }
		}
		public double RenderWidth
		{
			get { return (double) GetValue(RenderWidthProperty); }
			set { SetValue(RenderWidthProperty, value); }
		}
		public double RenderHeight
		{
			get { return (double) GetValue(RenderHeightProperty); }
			set { SetValue(RenderHeightProperty, value); }
		}
	}
}
 