using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Core.Helpers
{
	public static class BindingHelpers
	{
		//TODO should handle other focused elements/Text Input controls besides TextBox? 
		public static void ForceUpdateFocusedBindings()
		{
			var focusedElement = Keyboard.FocusedElement as FrameworkElement;
			if (focusedElement is TextBox)
			{
				var expression = focusedElement.GetBindingExpression(TextBox.TextProperty);
				expression?.UpdateSource();
			}
		}

		enum J
		{
			q,
			r,
			o,
			w,
		}

	}
}
