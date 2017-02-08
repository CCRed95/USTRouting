using System.ComponentModel;
using Core.Markup;
using Material.Design;
using Material.Design.Text;

namespace Material.Markup.Converters
{
	public class TextRotationToAngleConverter : XAMLConverter<TextRotation, NULLPARAM, double>
	{
		public override double Convert(TextRotation textRotation, NULLPARAM param)
		{
			switch (textRotation)
			{
				case TextRotation.None:
					return 0;
				case TextRotation.Left:
					return -90;
				case TextRotation.Right:
					return 90;
				default:
					throw new InvalidEnumArgumentException(nameof(textRotation), (int) textRotation, typeof (TextRotation));
			}
		}
	}
}
