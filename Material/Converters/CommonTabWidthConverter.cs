using System.Windows.Controls;
using Core.Markup;

namespace Material.Converters
{
public class CommonTabWidthConverter : XAMLConverter<TabControl, double, NULLPARAM, double>
	{
		public override double Convert(TabControl arg1, double arg2, NULLPARAM param)
		{
			return arg2 / arg1.Items.Count;
		}
	}
}
