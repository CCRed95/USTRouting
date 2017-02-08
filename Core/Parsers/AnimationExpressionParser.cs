using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;
using System.Windows.Media.Animation;
using Core.Animation;
using Core.Exceptions;

namespace Core.Parsers
{
	public enum CustomTimeSpanSuffix
	{
		Unknown,
		Milliseconds,
		Seconds,
		Minutes
	}
	public class AnimationExpressionParser
	{
		private readonly Tokenizer tokenizer;

		public AnimationExpressionParser(string expression)
		{
			tokenizer = new Tokenizer(expression);
		}

		//  rootBorder.Opacity .4s [.2->.9] .2s EaseIn Cubic/>
		public AnimationTimeline Parse()
		{
			var builder = new AnimationTimelineBuilder<DoubleAnimation>();

			var targetName = scanIdentifer();
			builder.SetTargetName(targetName);

			char c;
			if (!tokenizer.TryRead(out c))
				throw new FormatException("No target property specified.");

			if (c != '.')
				throw new FormatException("Expected period accessor after target name.");

			var targetProperty = scanIdentifer();
			builder.SetTargetProperty(targetProperty);
			tokenizer.SkipWhiteSpace();

			var beginTime = scanTimeSpanLiteral();
			builder.SetBeginTime(beginTime);
			tokenizer.SkipWhiteSpace();

			var progressionBlock = scanProgressionBlock();
			builder.SetProgressionBlock(progressionBlock);
			tokenizer.SkipWhiteSpace();

			var duration = scanTimeSpanLiteral();
			builder.SetDuration(duration);
			tokenizer.SkipWhiteSpace();

			var easingMode = scanIdentifer();
			tokenizer.SkipWhiteSpace();
			var easingFunctionType = scanIdentifer();

			NumberLiteralToken param1 = null;
			NumberLiteralToken param2 = null;

			tokenizer.SkipWhiteSpace();
			if (tokenizer.TryPeek(out c))
			{
				param1 = scanNumericLiteral();
				tokenizer.SkipWhiteSpace();
				if (tokenizer.TryPeek(out c))
				{
					param2 = scanNumericLiteral();
				}
			}
			builder.SetEasing(easingMode, easingFunctionType, param1, param2);
			return builder.CompositeAnimation;
		}

		private IdentiferToken scanIdentifer()
		{
			var text = "";
			var isFirst = true;
			char c;
			while (tokenizer.TryRead(out c))
			{
				if (isFirst)
				{
					isFirst = false;
					if (c.IsDigit())
						throw new FormatException(FSR.Parse.IdentifierMustStartWithLetter(c));
					if (c.IsLetter() || c == '_')
						text += c;
					else
						throw new FormatException(FSR.Parse.IdentifierMustStartWithLetter(c));
				}
				else
				{
					if (c.IsLetterOrDigit() || c == '_')
						text += c;
					else
						break;
					//return new IdentiferToken(text);
				}
			}
			if (string.IsNullOrWhiteSpace(text))
				throw new FormatException(FSR.Parse.CannotParseIdentifier());

			tokenizer.Step(-1);

			return new IdentiferToken(text);
		}

		//TODO just 0 -> Timespan.Zero
		private TimeSpanLiteralToken scanTimeSpanLiteral()
		{
			var text = "";
			var suffix = CustomTimeSpanSuffix.Unknown;

			var hasDecimal = false;
			char c;
			char c2;
			while (tokenizer.TryRead(out c))
			{
				if (c == '.')
				{
					if (hasDecimal)
						throw new FormatException("TimeSpan literal cannot contain two decimals.");
					hasDecimal = true;
					text += c;
				}
				if (c.IsDigit())
				{
					text += c;
				}
				if (c == 's')
				{
					if (tokenizer.TryPeek(out c2))
					{
						if (c2.IsWhiteSpace())
						{
							suffix = CustomTimeSpanSuffix.Seconds;
							break;
						}
						throw new FormatException("Invalid TimeSpan literal suffix.");
					}
				}
				if (c == 'm')
				{
					if (tokenizer.TryPeek(out c2))
					{
						if (c2 == 's')
						{
							if (tokenizer.TryPeek(out c2, 1))
							{
								if (c2.IsWhiteSpace())
								{
									suffix = CustomTimeSpanSuffix.Milliseconds;
									break;
								}
								throw new FormatException("Invalid TimeSpan literal suffix.");
							}
							suffix = CustomTimeSpanSuffix.Milliseconds;
							break;
						}
						if (c2.IsWhiteSpace())
						{
							suffix = CustomTimeSpanSuffix.Minutes;
							break;
						}
						throw new FormatException("Invalid TimeSpan literal suffix.");
					}
				}
			}
			return new TimeSpanLiteralToken(text, suffix);
		}

		private ProgressionBlockSyntacticUnit scanProgressionBlock()
		{
			var text = new string[] { null, null, null };

			char c;
			char c2;
			var index = 0;

			if (tokenizer.Read() != '[')
			{
				throw new FormatException("Bracket Syntax for progression blocks.");
			}
			while (tokenizer.TryRead(out c))
			{
				if (c == ']')
					break;

				if (c == '-')
				{
					if (tokenizer.TryPeek(out c2))
					{
						if (c2 == '>')
						{
							index++;
							tokenizer.Step(1);
							text[index] = "";
						}
					}
				}
				else
				{
					if (text[index] == null)
						text[index] = "";
					text[index] = text[index] + c;
				}
			}
			var t0 = text[0] != null;
			var t1 = text[1] != null;
			var t2 = text[2] != null;

			if (t0 && !t1 & !t2)
			{
				return new ProgressionBlockSyntacticUnit
				{
					To = new UnknownLiteralToken(text[0])
				};
			}
			if (t0 && t1 & !t2)
			{
				return new ProgressionBlockSyntacticUnit
				{
					From = new UnknownLiteralToken(text[0]),
					To = new UnknownLiteralToken(text[1])
				};
			}
			if (t0 && t1 && t2)
			{
				return new ProgressionBlockSyntacticUnit
				{
					From = new UnknownLiteralToken(text[0]),
					By = new UnknownLiteralToken(text[1]),
					To = new UnknownLiteralToken(text[2])
				};
			}

			throw new FormatException("Progression Block Syntactic Unit cannot be parsed.");
		}

		private NumberLiteralToken scanNumericLiteral()
		{
			var text = "";

			var hasDecimal = false;
			char c;
			while (tokenizer.TryRead(out c))
			{
				if (c == '.')
				{
					if (hasDecimal)
						throw new FormatException("Numeric literal cannot contain two decimals.");
					hasDecimal = true;
					text += c;
				}
				else if (c.IsDigit())
				{
					text += c;
				}
				else if (c.IsWhiteSpace() || c == '\0')
				{
					break;
				}
				else
				{
					throw new FormatException("Invalid character in numeric literal.");
				}
			}
			return new NumberLiteralToken(text);
		}
	}
}