using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Security;
using Core.Layout;

namespace Core.Markup.TypeConverters
{
	public class CornerRadiusScalingConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext typeDescriptorContext, Type sourceType)
		{
			switch (Type.GetTypeCode(sourceType))
			{
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
				case TypeCode.String:
					return true;
				default:
					return false;
			}
		}

		public override bool CanConvertTo(ITypeDescriptorContext typeDescriptorContext, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string);
		}

		public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			var str = source as string;
			if (str != null)
				return FromString(str, cultureInfo);
			return new CornerRadiusScaling(Convert.ToDouble(source, cultureInfo));
		}

		[SecurityCritical]
		public override object ConvertTo(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value, Type destinationType)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			if (null == destinationType)
				throw new ArgumentNullException(nameof(destinationType));
			if (!(value is CornerRadiusScaling))
			{
				throw new ArgumentException(@"Unexpected parameter type. Must be CornerRadiusScale", nameof(value));
			}
			var cr = (CornerRadiusScaling)value;
			if (destinationType == typeof(string))
				return $"{cr.TopLeft} {cr.TopRight} {cr.BottomRight} {cr.BottomLeft}";

			throw new ArgumentException(@"CannotConvertType", nameof(value));
		}

		internal static CornerRadiusScaling FromString(string s, CultureInfo cultureInfo)
		{
			var values = s.Split(' ').ToList();
			var numericValues = new List<double>();
			foreach (var value in values)
			{
				double numericValue;
				if (!double.TryParse(value, out numericValue))
				{
					throw new FormatException($"Could not convert source \'{s}\' to CornerRadiusScaling. Double parse \'{value}\' not valid.");
				}
				numericValues.Add(numericValue);
			}
			if (numericValues.Count == 1)
			{
				return new CornerRadiusScaling(numericValues[0]);
			}
			if (numericValues.Count == 4)
			{
				return new CornerRadiusScaling(numericValues[0], numericValues[1], numericValues[2], numericValues[3]);
			}
			throw new FormatException($"Could not convert source \'{s}\' to CornerRadiusScaling. Invalid format or number of arguments.");
		}
	}
}
