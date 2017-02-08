using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Markup.Converters
{
	public class StringPrefixConverter : XAMLConverter<string, string, string>
	{
		public override string Convert(string arg1, string param)
		{
			return param + arg1;
		}
	}
}
