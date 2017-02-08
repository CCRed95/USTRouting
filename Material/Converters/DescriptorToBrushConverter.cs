using System;
using System.Windows.Media;
using Core.Markup;
using Material.Design;
using Material.Design.Descriptors;
using Material.Extensions;

namespace Material.Converters
{
	public class DescriptorToBrushConverter : XAMLConverter<MaterialSet, AbstractMaterialDescriptor, NULLPARAM, Brush>
	{
		public override Brush Convert(MaterialSet materialSet, AbstractMaterialDescriptor descriptor, NULLPARAM param)
		{
			//TODO dont return red. use transparent MaterialSet as default 
			if (materialSet == null || descriptor == null)
				return Brushes.Red;
			return descriptor.GetMaterial(materialSet);
		}
	}
	public class HighContrastDescriptorToBrushConverter : XAMLConverter<
		MaterialSet,
		AbstractMaterialDescriptor,
		bool,
		SolidColorBrush,
		double,
		NULLPARAM,
		SolidColorBrush>
	{
		public override SolidColorBrush Convert(
			MaterialSet materialSet,
			AbstractMaterialDescriptor descriptor,
			bool isHighConstrast,
			SolidColorBrush overlayedBackground,
			double highContrastBindingThreshold,
			NULLPARAM param)
		{
			//TODO dont return red. use transparent MaterialSet as default 
			if (materialSet == null || descriptor == null)
				return Brushes.Red;

			var originalBrush = descriptor.GetMaterial(materialSet);

			if (!isHighConstrast)
				return originalBrush;

			var invertedBrush = originalBrush.Invert();

			//var originalBrushDelta = originalBrush.Differential(overlayedBackground);
			//var invertedBrushDelta = invertedBrush.Differential(overlayedBackground);

			var originalHSL = originalBrush.Color.ToHSL();
			var invertedHSL = invertedBrush.Color.ToHSL();
			var overlayedHSL = overlayedBackground.Color.ToHSL();

			var lightnessDifferenceToOriginal = Math.Abs(originalHSL.L - overlayedHSL.L);
			var lightnessDifferenceToInverted = Math.Abs(invertedHSL.L - overlayedHSL.L);

			//if (lightnessDifferenceToInverted < lightnessDifferenceToOriginal)
			if (lightnessDifferenceToOriginal > highContrastBindingThreshold)
			{
				return originalBrush;
			}
			return invertedBrush;
		}
	}
}