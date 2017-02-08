 using System;
 using System.IO;
using System.Windows.Markup;

namespace Material.Controls.Documents
{
	public static class FlexDocumentReaderRedo
	{
		//TODO make this better. catch exceptions
		public static FlexDocumentRedo ParseDocument(string filePath)
		{
			using (var stream = new FileStream(filePath, FileMode.Open))
			{
				var parserContext = new ParserContext();

				var configObject = XamlReader.Load(stream, parserContext);
				var chartConfigObject = (FlexDocumentRedo)configObject;
				return chartConfigObject;
			}
		}
		//public static FlexDocument ParseDocumentFromStream(Stream xmlStream, Version version)
		//{
		//	var parserContext = new ParserContext();
		//	//var configFileStream = new FileStream(configFilePath, FileMode.Open);
		//	var configObject = XamlReader.Load(xmlStream, parserContext);
		//	var chartConfigObject = (FlexDocument)configObject;
		//	return chartConfigObject;
		//}

		//private static Stream InjectDocumentVersionFallback(string configFilePath, Version currentVersion)
		//{
		//	const string versionTag = "<!--VERSION ";
		//	const string versionEndTag = "-->";
		//	const string endVersionTag = "<!--ENDVERSION-->";
		//	var fileContents = File.ReadAllText(configFilePath);
		//	var versionInfoIndex = fileContents.IndexOf(versionTag, StringComparison.Ordinal);
		//	while (versionInfoIndex > 1)
		//	{
		//		var versionInfoEndIndex = fileContents.IndexOf(versionEndTag, versionInfoIndex, StringComparison.Ordinal);
		//		var versionInfoValueIndex = versionInfoIndex + versionTag.Length;
		//		var versionInfoValueLength = (versionInfoEndIndex - versionInfoValueIndex);
		//		var versionstr = fileContents.Substring(versionInfoValueIndex, versionInfoValueLength);
		//		var requiredVersion = Version.Parse(versionstr);
		//		var lastremovalbufferlength = 0;
		//		if (requiredVersion > currentVersion)
		//		{
		//			var endVersionTagIndex = fileContents.IndexOf(endVersionTag, versionInfoValueIndex, StringComparison.Ordinal);
		//			lastremovalbufferlength = endVersionTagIndex - versionInfoIndex;
		//			fileContents = fileContents.Remove(versionInfoIndex, lastremovalbufferlength);
		//		}
		//		versionInfoIndex = fileContents.IndexOf(versionTag, versionInfoEndIndex - lastremovalbufferlength, StringComparison.Ordinal);
		//	}
		//	return fileContents.ToStream();
		//}
	}
}
