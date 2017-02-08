using Core.Markup;
using Material.Design;
using Material.Design.Providers;

namespace Material.Markup.Converters
{
	public class MaterialProviderToFirstMaterialConverter : XAMLConverter<IMaterialProvider, NULLPARAM, Design.MaterialSet>
	{
		public override MaterialSet Convert(IMaterialProvider materialProvider, NULLPARAM param)
		{
			var context = new ProviderContext(2);
			materialProvider.Reset(context);

			var i = materialProvider.ProvideNext(context);
			return i;
		}
	}
}
