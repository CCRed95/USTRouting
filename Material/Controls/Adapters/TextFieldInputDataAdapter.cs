using System;
using System.Windows;
using System.Windows.Controls;
using Core.Extensions;
using Material.Extensions;

namespace Material.Controls.Adapters
{
	public class TextFieldInputDataAdapter
	{
		protected IFrameworkInputElement InputElement { get; }

		public TextFieldInputDataAdapter(IFrameworkInputElement inputElement)
		{
			InputElement = inputElement;
		}

		public string Text
		{
			get
			{
				if (InputElement is TextBox)
					return InputElement.As<TextBox>().Text;
				if (InputElement is PasswordBox)
					return InputElement.As<PasswordBox>().Password;
				throw new NotSupportedException(
					$"The type \'{InputElement.GetType().Name}\' is not supported with \'TextFieldInputDataAdapter\'.");
			}
		}
	}
}

