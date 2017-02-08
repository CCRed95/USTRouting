namespace Core.Markup.Converters
{
	public class StringSuffixConverter : XAMLConverter<string, string, string>
	{
		public override string Convert(string arg1, string param)
		{
			return arg1 + param;
		}
	}
}
