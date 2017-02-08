namespace Core.Markup.Converters
{
	public class NotConverter : XAMLConverter<bool?, NULLPARAM, bool>
	{
		protected override bool? ConvertArg1(object arg)
		{
			return bool.Parse(arg.ToString());
		}

		public override bool Convert(bool? value, NULLPARAM param)
		{
			if (!value.HasValue)
				return true;
			return !value.Value;
		}
	}
}
