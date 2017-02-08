namespace Core.FlexParser
{
	public abstract class FlexParser<TResult>// where TLexer : FlexLexerBase, new()
	{
		public abstract TResult Parse(string expression);
	}
}
