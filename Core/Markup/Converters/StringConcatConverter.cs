namespace Core.Markup.Converters
{
	public class StringConcatConverter : XAMLConverter<string, string, NULLPARAM, string>
	{
		public override string Convert(string arg1, string arg2, NULLPARAM param)
		{
			return arg1 + " " + arg2;
		}
	}
}
