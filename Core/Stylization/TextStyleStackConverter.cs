using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using Core.Collections;

namespace Core.Stylization
{
	public class TextStyleStackConverter : TypeConverter
	{
		public Type TargetType => typeof(TextStyleStack);

		protected virtual IComparer Comparer => FlexInvariantComparar.Default;

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
				return TextStyleStack.Parse((string)value);
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
				if (destinationType == null)
					throw new ArgumentNullException(nameof(destinationType));

				if (value == null)
					throw new ArgumentNullException(nameof(value));
				
				var strValue = ConvertToInvariantString(context, value);
				if (destinationType == typeof(string)) return value.ToString();
				if (destinationType == typeof(InstanceDescriptor))
				{
					var info = TargetType.GetField(strValue);
					if (info != null) return new InstanceDescriptor(info, null);
				}
				if (destinationType == TargetType)
					return TextStyleStack.Parse(strValue);
				throw new Exception("convertto failed");
			}
			catch
			{
				throw new Exception("convertto failed unknown");
			}
		}

		public override bool IsValid(ITypeDescriptorContext context, object value)
		{
			try
			{
				return TextStyleStack.IsValidFormat((string) value);
			}
			catch
			{
				throw new Exception("isvalid failed");
			}

		}
	}
}
