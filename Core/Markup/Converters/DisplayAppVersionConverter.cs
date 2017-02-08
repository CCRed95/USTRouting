using System;
using System.Reflection;
using System.Windows.Markup;

namespace Core.Markup.Converters
{
	public class DisplayAppVersionConverter : XAMLConverter<string, NULLPARAM, string>
	{
		public override string Convert(string arg1, NULLPARAM param)
		{
			return arg1 + " RELEASE " + Assembly.GetEntryAssembly().GetName().Version;
		}
	}
	public class AppVersionExtension : MarkupExtension
	{
		public string VersionPrefix { get; }

		public AppVersionExtension(object versionPrefix)
		{
			VersionPrefix = Convert.ToString(versionPrefix);
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return $"{VersionPrefix.ToUpper()} RELEASE {Assembly.GetEntryAssembly().GetName().Version}";
		}
	}
}
