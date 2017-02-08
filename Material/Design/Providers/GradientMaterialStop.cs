using System.Windows;
using Core.Helpers.DependencyHelpers;

namespace Material.Design.Providers
{
	public class GradientMaterialStop : DependencyObject
	{
		public static readonly DependencyProperty MaterialSetProperty = DP.Register(
			new Meta<GradientMaterialStop, MaterialSet>());

		public static readonly DependencyProperty OffsetProperty = DP.Register(
			new Meta<GradientMaterialStop, double>(1));

		public GradientMaterialStop() { }
		
		public GradientMaterialStop(MaterialSet materialSet)
		{
			MaterialSet = materialSet;
		}
		public GradientMaterialStop(MaterialSet materialSet, double offset) : this(materialSet)
		{
			Offset = offset;
		}

		public MaterialSet MaterialSet
		{
			get { return (MaterialSet)GetValue(MaterialSetProperty); }
			set { SetValue(MaterialSetProperty, value); }
		}
		public double Offset
		{
			get { return (double)GetValue(OffsetProperty); }
			set { SetValue(OffsetProperty, value); }
		}
	}
}
