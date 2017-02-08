using System.Collections;
using System.Linq;
using System.Windows;
using Core.Markup;

namespace Material.Converters
{
	public class LinqAnyToVisibilityConverter : XAMLConverter<IEnumerable, NULLPARAM, Visibility>
	{
		public override Visibility Convert(IEnumerable arg1, NULLPARAM param)
		{
			return arg1 != null && arg1.Cast<object>().Any() ? Visibility.Collapsed : Visibility.Visible;
		}
	}
}
