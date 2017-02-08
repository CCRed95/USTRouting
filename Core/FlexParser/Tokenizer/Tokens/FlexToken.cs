using System;
using System.ComponentModel;
using System.Diagnostics;
using Core.Parsers;

namespace Core.FlexParser.Tokenizer.Tokens
{
	public abstract class FlexToken
	{
		public string Text { get; }

		protected FlexToken(string text)
		{
			Text = text;
		}
	}

	public interface IRepresentsValue<out TValue>
	{
		TValue ActualValue { get; }
	}

	[DebuggerDisplay("IDT: {Text}")]
	public class IdentiferFlexToken : FlexToken, IRepresentsValue<object>
	{
		public object ActualValue => Text;

		public IdentiferFlexToken(string text) : base(text)
		{
		}
	}

	[DebuggerDisplay("FPLT: {Text}")]
	public class FloatingPointLiteralFlexToken : FlexToken, IRepresentsValue<double>
	{
		public double ActualValue
		{
			get
			{
				double actualValue;
				if (!double.TryParse(Text, out actualValue))
					throw new FormatException($"Cannot parse \'double\' from text \'{Text}\'.");
				return actualValue;
			}
		}

		public FloatingPointLiteralFlexToken(string text) : base(text)
		{
		}
	}

	[DebuggerDisplay("ILT: {Text}")]
	public class IntegerLiteralFlexToken : FlexToken, IRepresentsValue<int>
	{
		public int ActualValue
		{
			get
			{
				int actualValue;
				if (!int.TryParse(Text, out actualValue))
					throw new FormatException($"Cannot parse \'int\' from text \'{Text}\'.");
				return actualValue;
			}
		}

		public IntegerLiteralFlexToken(string text) : base(text)
		{
		}
	}

	[DebuggerDisplay("TSLT: {Text} {Suffix.ToString()}")]
	public class TimeSpanLiteralToken : FlexToken, IRepresentsValue<TimeSpan>
	{
		public CustomTimeSpanSuffix Suffix { get; }

		public TimeSpanLiteralToken(string text, CustomTimeSpanSuffix suffix) : base(text)
		{
			Suffix = suffix;
		}


		public TimeSpan ActualValue
		{
			get
			{
				TimeSpan actualValue;
				if (!TimeSpan.TryParse(Text, out actualValue))
				{
					double textDoubleValue;
					if (!double.TryParse(Text, out textDoubleValue))
						throw new FormatException($"Cannot parse \'double\' from text \'{Text}\' for custom timespan.");

					switch (Suffix)
					{
						case CustomTimeSpanSuffix.Milliseconds:
							return TimeSpan.FromMilliseconds(textDoubleValue);
						case CustomTimeSpanSuffix.Seconds:
							return TimeSpan.FromSeconds(textDoubleValue);
						case CustomTimeSpanSuffix.Minutes:
							return TimeSpan.FromMinutes(textDoubleValue);
						default:
							throw new InvalidEnumArgumentException();
					}
				}
				return actualValue;
			}
		}
	}
}
