using System.Windows;
using Core.Markup;
using Material.Controls.Validation;

namespace Material.Markup.Converters
{
	public class HasValidatorToVisibilityConverter : XAMLConverter<StringValidator, NULLPARAM, Visibility>
	{
		public override Visibility Convert(StringValidator arg1, NULLPARAM param)
		{
			return arg1 == null ? Visibility.Collapsed : Visibility.Visible;
		}
	}
}
