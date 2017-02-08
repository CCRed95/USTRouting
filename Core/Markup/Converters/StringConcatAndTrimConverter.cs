namespace Core.Markup.Converters
{
	public class StringConcatAndTrimConverter : XAMLConverter<string, string, bool?, string>
	{
		protected override string ConvertArg1(object arg)
		{
			return arg.ToString();
			//return base.ConvertArg1(arg);
		}

		protected override string ConvertArg2(object arg)
		{
			return arg.ToString();
			//return base.ConvertArg2(arg);
		}

		protected override bool? ConvertParam(object param)
		{
			if (param == null)
				return null;
			return param.ToString().ToLower() == "true";
		}

		public override string Convert(string arg1, string arg2, bool? shouldSpace)
		{
			var space = "";
			if (shouldSpace.HasValue && shouldSpace.Value)
				space = " ";

			return (arg1 + space + arg2).Trim();
		}
	}
}
