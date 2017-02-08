using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Core.Stylization
{
	[ContentProperty("Setters")]
	public class StyleVariant 
	{
		public SetterBaseCollection Setters { get; set; }

		public StyleVariant()
		{
			Setters = new SetterBaseCollection();
		}
	}
}
