using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using Core.Extensions;
using Core.Layout;

namespace Core.Markup.TypeConverters
{
	public class PercentageConverter : TypeConverter
	{
		public Type TargetType => typeof(Percentage);

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string) || TargetType.IsAssignableFrom(sourceType))
				return true;
			return false;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor) || destinationType == TargetType)
				return true;
			return false;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{

			if (value == null)
				return null;

			var stringValue = value.ToString().Trim().ToLower();

			string numericValue = null;
			if (!stringValue.EndsWith("%"))
			{
				throw new FormatException("Percentage must end with %.");
			}
			numericValue = stringValue.Replace("%", "").Trim();
			if (numericValue.IsNullOrWhiteSpace())
				throw new FormatException("Percentage conversion error.");

			return new Percentage(double.Parse(numericValue));
		}
	}
}
