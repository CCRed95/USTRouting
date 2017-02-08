using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using Material.Design.RelativeFontSize;

namespace Material.Markup.TypeConverters
{
	public class RelativeFontSizeConverter : TypeConverter
	{
		public Type TargetType => typeof(AbstractRelativeFontSize);

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
			try
			{
				if (value == null)
					return null;

				var stringValue = value.ToString().Trim();

				Operation? operation = null;

				if (stringValue.StartsWith("+"))
				{
					operation = Operation.Add;
				}
				else if (stringValue.StartsWith("-"))
				{
					operation = Operation.Subtract;
				}
				else if (stringValue.StartsWith("x") || stringValue.StartsWith("*"))
				{
					operation = Operation.Multiply;
				}
				else if (stringValue.StartsWith("/"))
				{
					operation = Operation.Divide;
				}
				if(!operation.HasValue)
					throw new NotSupportedException();

				return new MathRelativeFontSize
				{
					Operation = operation.Value,
					Parameter = double.Parse(stringValue.Substring(1))
				};
			}
			catch
			{
				throw new Exception("convertfrom failed");
			}
		}


		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			try
			{
				//{
				//	destinationType.ShouldNotBeNull();
				//	value.ShouldNotBeNull();
				//	var strValue = ConvertToInvariantString(context, value);
				//	if (destinationType == typeof(string)) return value.ToString();
				//	if (destinationType == typeof(InstanceDescriptor))
				//	{
				//		var info = TargetType.GetField(strValue);
				//		if (info != null) return new InstanceDescriptor(info, null);
				//	}
				//	if (destinationType == TargetType)
				//		return FlexEnum.Parse(TargetType, strValue);
				throw new Exception("convertto failed");
			}
			catch
			{
				throw new Exception("convertto failed unknown");
			}
		}

		//public override bool IsValid(ITypeDescriptorContext context, object value)
		//{
		//	try
		//	{
		//		return FlexEnum.IsDefined(TargetType, value);
		//	}
		//	catch
		//	{
		//		throw new Exception("isvalid failed");
		//	}

		//}
	}
}
