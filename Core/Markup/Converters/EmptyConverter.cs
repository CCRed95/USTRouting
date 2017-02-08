using System;
namespace Core.Markup.Converters
{
	public class EmptyConverter : XAMLConverter<object, NULLPARAM, object>
	{
		public override object Convert(object arg1, NULLPARAM param)
		{
			return arg1;
		}
	}
}
//.(FrameworkElement.Height)