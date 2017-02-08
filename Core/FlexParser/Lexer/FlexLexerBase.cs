using Core.FlexParser.Tokenizer;

namespace Core.FlexParser.Lexer
{
	public abstract class FlexLexerBase
	{
		protected readonly string _expression;
		protected readonly FlexTokenizerBase _tokenizer;
		
		protected FlexLexerBase(string expression)
		{
			_expression = expression;
			_tokenizer = new FlexTokenizerBase(expression);
			
		}

	}
}
