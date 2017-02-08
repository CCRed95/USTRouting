using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Windows;

namespace Core.Markup.Converters
{
	public class AspectRatioLengthConverter : XAMLConverter<double, AspectRatio, double>
	{
		public override double Convert(double arg1, AspectRatio param)
		{
			return arg1*(param.Height/param.Width);
		}
	}

	[TypeConverter(typeof(AspectRatioConverter))]
	public class AspectRatio
	{
		public double Width { get; set; }
		public double Height { get; set; }

		public AspectRatio() { }

		public AspectRatio(double width, double height)
		{
			Width = width;
			Height = height;
		}
	}
	public class AspectRatioConverter : TypeConverter
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
			throw new FormatException("Invalid convert");
		}

		[SecurityCritical]
		public override object ConvertTo(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value, Type destinationType)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			if (null == destinationType)
				throw new ArgumentNullException(nameof(destinationType));
			if (!(value is AspectRatio))
			{
				throw new ArgumentException(@"Unexpected parameter type. Must be AspectRatio", nameof(value));
			}
			var cr = (AspectRatio)value;
			if (destinationType == typeof (string))
				return $"{cr.Width}:{cr.Height}";

			throw new ArgumentException(@"CannotConvertType", nameof(value));
		}

		internal static AspectRatio FromString(string s, CultureInfo cultureInfo)
		{
			var values = s.Replace(" ", "").Split(':').ToList();
			var numericValues = new List<double>();
			foreach (var value in values)
			{
				double numericValue;
				if (!double.TryParse(value, out numericValue))
				{
					throw new FormatException($"Could not convert source \'{s}\' to AspectRatio. Double parse \'{value}\' not valid.");
				}
				numericValues.Add(numericValue);
			}
			if (numericValues.Count == 2)
			{
				return new AspectRatio(numericValues[0], numericValues[1]);
			}
			throw new FormatException($"Could not convert source \'{s}\' to AspectRatio. Format should be \'Width:Height\'.");
		}
	}
}
