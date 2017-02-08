using System.Windows.Controls;
using System.Windows.Media;
using Core.Markup;
using Material.Design;
using Material.Design.Descriptors;
using Material.Design.Providers;

namespace Material.Converters
{
	public class MaterialProviderToTabAccent : XAMLConverter<TabControl, NULLPARAM, SolidColorBrush>
	{
		public IMaterialProvider provider = GradientMaterialProvider.RainbowRefractionOrder;
		public TabControl last;
		public override SolidColorBrush Convert(TabControl arg1, NULLPARAM param)
		{
			var context = new ProviderContext(arg1.Items.Count);
			if (last == null || !Equals(arg1, last))
			{
				provider.Reset(context);
				last = arg1;
			}
			var set = provider.ProvideNext(context);
			var descr = new LuminosityMaterialDescriptor(Luminosity.P600);
			return descr.GetMaterial(set);
		}
	}
}
