using System.Windows;
using System.Windows.Controls;
using Core.Controls;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls
{
	public class Divider : FlexControl 
	{
		public static readonly DependencyProperty DividerThicknessProperty = DP.Register(
			new Meta<Divider, double>(1));

		public static readonly DependencyProperty OrientationProperty = DP.Add(
			StackPanel.OrientationProperty, new Meta<Divider, Orientation>());


		public double DividerThickness
		{
			get { return (double) GetValue(DividerThicknessProperty); }
			set { SetValue(DividerThicknessProperty, value); }
		}
		public Orientation Orientation
		{
			get { return (Orientation) GetValue(OrientationProperty); }
			set { SetValue(OrientationProperty, value); }
		}

		static Divider()
		{
			OverrideDefaultStyleKey<Divider>();
		}
	}
}
