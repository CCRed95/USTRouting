using System.Windows;
using System.Windows.Media;
using Core.Markup;
using Material.Design;
using Material.Design.Descriptors;
using Material.Static;

namespace Material.Markup.Converters
{
	public class MaterialDescriptorToBrushConverter : XAMLConverter<AbstractMaterialDescriptor, MaterialSet, NULLPARAM, SolidColorBrush>
	{
		protected override AbstractMaterialDescriptor ConvertArg1(object arg)
		{
			return (arg == DependencyProperty.UnsetValue) ? Descriptors.P500Descriptor : (AbstractMaterialDescriptor)arg;
		}

		public override SolidColorBrush Convert(AbstractMaterialDescriptor arg1, MaterialSet arg2, NULLPARAM param)
		{
			if (arg1 == null || arg2 == null)
				return Palette.Red.P500;
			return arg1.GetMaterial(arg2);
		}
	}
}
