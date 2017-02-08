using System.Windows;
using Core.Controls;
using Core.Helpers.DependencyHelpers;
using Material.Design;
using Material.Static;

namespace Material.Controls
{
	public class NumericIndicator : FlexControl
	{
		public static readonly DependencyProperty ThemeProperty = DP.Register(
			new Meta<NumericIndicator, MaterialSet>(Palette.Grey));
		public static readonly DependencyProperty TitleProperty = DP.Register(
			new Meta<NumericIndicator, string>("Title"));
		public static readonly DependencyProperty ValueProperty = DP.Register(
			new Meta<NumericIndicator, double>());
		public static readonly DependencyProperty LabelProperty = DP.Register(
			new Meta<NumericIndicator, string>("LBL"));

		public MaterialSet Theme
		{
			get { return (MaterialSet) GetValue(ThemeProperty); }
			set { SetValue(ThemeProperty, value); }
		}
		public string Title
		{
			get { return (string) GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		public double Value
		{
			get { return (double) GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}
		public string Label
		{
			get { return (string) GetValue(LabelProperty); }
			set { SetValue(LabelProperty, value); }
		}

		static NumericIndicator()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (NumericIndicator),
				new FrameworkPropertyMetadata(typeof (NumericIndicator)));
		}
	}
}
