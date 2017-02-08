using System.Text.RegularExpressions;

namespace Material.Controls.Validation
{
	public class EmailValidator : StringValidator
	{
		public override bool Validate(string value)
		{
			return Regex.IsMatch(value, 
				@"\A([A-z0-9.!#$%&'*+-/=?^_`{|}~()]{1,64})@([^-][A-z0-9-]*)([^-][^.].[A-z]{1,}[A-z]*)\Z",
				RegexOptions.IgnoreCase);
		}
	}
}
