using System.Windows;
using System.Windows.Markup;
using Core.Controls;

namespace Material.Controls
{
	[ContentProperty(nameof(Content))]
	public class Card : FlexContentControl
	{
		static Card()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof (Card), new FrameworkPropertyMetadata(typeof (Card)));
		}
		public Card() { }
	}
}
