using System.Windows;
using System.Windows.Media;
using Core.Markup;
using Material.Design;
using Material.Static;

namespace Material.Markup.Converters
{
	public class ConditionalMaterialInverter : XAMLConverter<MaterialSet, bool, Luminosity, SolidColorBrush>
	{
		protected override MaterialSet ConvertArg1(object arg)
		{
			return (arg == DependencyProperty.UnsetValue) ? Palette.Orange : (MaterialSet)arg;
		}

		public override SolidColorBrush Convert(MaterialSet arg1, bool arg2, Luminosity param)
		{
			return arg1.FromLuminosity(arg2 ? param : param.InvertedLuminosity);
		}
	}
}
