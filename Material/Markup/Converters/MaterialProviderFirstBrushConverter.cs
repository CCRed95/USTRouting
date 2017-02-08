using System;
using System.Collections.Generic;
using Core.Markup;
using Material.Design;
using Material.Design.Providers;
using Material.Static;

namespace Material.Markup.Converters
{
	public class MaterialProviderFirstBrushConverter : XAMLConverter<IMaterialProvider, NULLPARAM, Design.MaterialSet>
	{
		public override MaterialSet Convert(IMaterialProvider materialProvider, NULLPARAM param)
		{
			var context = new ProviderContext(10);
			materialProvider.Reset(context);
			return materialProvider.ProvideNext(context);
		}
	}

}
