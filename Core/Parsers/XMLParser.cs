using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Core.Parsers
{
	public static class XMLParser
	{
		public static T Parse<T>(string path)
		{
			using (var stream = File.OpenRead(path))
			{
				var parserContext = new ParserContext();
				var configObject = XamlReader.Load(stream, parserContext);
				var chartConfigObject = (T)configObject;
				return chartConfigObject;
			}
		}
		//public static async Task<T> ParseAsync<T>(string path)
		//{
		//	using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read,FileShare.Read, 1024, FileOptions.Asynchronous))
		//	{
		//		var parserContext = new ParserContext();
		//		var configObject = XamlReader.Load(stream, parserContext);
		//		var chartConfigObject = (T)configObject;
		//		return chartConfigObject;
		//	}
		//}
	}
}
