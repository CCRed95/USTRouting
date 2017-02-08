using System.Windows;
namespace Core.Markup.Converters
{
	public class NotNullToVisibilityConverter : XAMLConverter<object, NULLPARAM, Visibility>
	{
		public override Visibility Convert(object arg1, NULLPARAM param)
		{
			return arg1 == null ? Visibility.Collapsed : Visibility.Visible;
		}
	}
}
