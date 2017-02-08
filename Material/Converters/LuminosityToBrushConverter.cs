using System.Windows.Media;
using Core.Markup;
using Material.Design;

namespace Material.Converters
{
	public class LuminosityToBrushConverter : XAMLConverter<MaterialSet, Luminosity, NULLPARAM, Brush>
	{
		public override Brush Convert(MaterialSet materialSet, Luminosity luminosity, NULLPARAM param)
		{
			return materialSet.FromLuminosity(luminosity);
		}
	}
}