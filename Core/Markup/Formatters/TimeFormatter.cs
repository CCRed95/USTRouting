using System;

namespace Core.Markup.Formatters
{
	public class TimeFormatter : XAMLConverter<DateTime, bool, NULLPARAM, string>
	{
		public override string Convert(DateTime arg1, bool arg2, NULLPARAM param)
		{
			var str = arg1.ToString("t");
			if (arg2)
			{
				str = str.Replace("AM", "PM");
			}
			else
			{
				str = str.Replace("PM", "AM");
			}
			return str;
		}
	}
}