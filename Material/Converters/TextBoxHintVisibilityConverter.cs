using System.Windows;
using System.Windows.Controls;
using Core.Extensions;
using Core.Markup;

namespace Material.Converters
{
	public class TextBoxHintVisibilityConverter : XAMLConverter<string, bool, NULLPARAM, Visibility>
	{
		public override Visibility Convert(string text, bool focused, NULLPARAM param)
		{
			if (focused)
				return Visibility.Hidden;
			
			return text.IsNullOrWhiteSpace() ? Visibility.Visible : Visibility.Hidden;
		}
	}
		public class PasswordBoxHintVisibilityConverter : XAMLConverter<PasswordBox, bool, NULLPARAM, Visibility>
	{
		public override Visibility Convert(PasswordBox passwordBox, bool focused, NULLPARAM param)
		{
			if (focused)
				return Visibility.Hidden;
			
			return passwordBox.Password.IsNullOrWhiteSpace() ? Visibility.Visible : Visibility.Hidden;
		}
	}
}
