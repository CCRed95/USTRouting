using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Core.Helpers.DependencyHelpers;
using Core.Markup.TypeConverters;

namespace Core.Layout
{
	[TypeConverter(typeof(CornerRadiusScalingConverter))]
	public class CornerRadiusScaling : Freezable
	{
		//TODO make these of type Percentage
		public static readonly DependencyProperty TopLeftProperty = DP.Register(
			new Meta<CornerRadiusScaling, double>(1));

		public static readonly DependencyProperty TopRightProperty = DP.Register(
			new Meta<CornerRadiusScaling, double>(1));

		public static readonly DependencyProperty BottomRightProperty = DP.Register(
			new Meta<CornerRadiusScaling, double>(1));

		public static readonly DependencyProperty BottomLeftProperty = DP.Register(
			new Meta<CornerRadiusScaling, double>(1));


		public double TopLeft
		{
			get { return (double)GetValue(TopLeftProperty); }
			set { SetValue(TopLeftProperty, value); }
		}
		public double TopRight
		{
			get { return (double)GetValue(TopRightProperty); }
			set { SetValue(TopRightProperty, value); }
		}
		public double BottomRight
		{
			get { return (double)GetValue(BottomRightProperty); }
			set { SetValue(BottomRightProperty, value); }
		}
		public double BottomLeft
		{
			get { return (double)GetValue(BottomLeftProperty); }
			set { SetValue(BottomLeftProperty, value); }
		}
		

		public CornerRadiusScaling() { }

		public CornerRadiusScaling(double uniform) : this(uniform, uniform, uniform, uniform) { }

		public CornerRadiusScaling(double topLeft, double topRight, double bottomRight, double bottomLeft)
		{
			TopLeft = topLeft;
			TopRight = topRight;
			BottomRight = bottomRight;
			BottomLeft = bottomLeft;
		}

		protected override Freezable CreateInstanceCore()
		{
			return new CornerRadiusScaling();
		}
	}
}
