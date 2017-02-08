namespace Core.Markup.Converters
{
	public class CompoundCommandParameter
	{
		public object Item1 { get; }
		public object Item2 { get; }

		public CompoundCommandParameter(object item1, object item2)
		{
			Item1 = item1;
			Item2 = item2;
		}
	}
	public class CompoundCommandParameterConverter : XAMLConverter<object, object, NULLPARAM, CompoundCommandParameter>
	{
		public override CompoundCommandParameter Convert(object arg1, object arg2, NULLPARAM param)
		{
			return new CompoundCommandParameter(arg1, arg2);
		}
	}
}
