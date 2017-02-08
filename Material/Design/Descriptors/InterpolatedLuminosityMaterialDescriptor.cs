using System.Windows.Media;
using Material.Extensions;

namespace Material.Design.Descriptors
{
	public class InterpolatedLuminosityMaterialDescriptor : AbstractMaterialDescriptor
	{
		public Luminosity Luminosity1 { get; }

		public Luminosity Luminosity2 { get; }

		public double Progression { get; }


		public override SolidColorBrush GetMaterial(MaterialSet materialSet)
		{
			var material1 = materialSet.FromLuminosity(Luminosity1); 
			var material2 = materialSet.FromLuminosity(Luminosity2);

			var interpolatedMaterial = material1.Blend(material2, Progression);

			return interpolatedMaterial.WithOpacity(Opacity);
		}

		public InterpolatedLuminosityMaterialDescriptor(
			Luminosity luminosity1, 
			Luminosity luminosity2,
			double progression, 
			double opacity = 1.0)
		{
			Luminosity1 = luminosity1;
			Luminosity2 = luminosity2;
			Progression = progression;
			Opacity = opacity;
		}
	}
}