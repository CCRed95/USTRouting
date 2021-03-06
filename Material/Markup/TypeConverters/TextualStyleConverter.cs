﻿using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Security;
using Material.Design.Text;
using Material.Parsers;

namespace Material.Markup.TypeConverters
{
	public sealed class TextualStyleConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext typeDescriptorContext, Type sourceType)
		{
			return sourceType == typeof(string);
		}

		public override bool CanConvertTo(ITypeDescriptorContext typeDescriptorContext, Type destinationType)
		{
			return destinationType == typeof (InstanceDescriptor); // || destinationType == typeof(string);
			//	return destinationType == typeof(string);
		}

		public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var str = source as string;
			if (str != null)
			{
				var parser = new TextualStyleParser((string)source);
				var selector = parser.Parse();
				return selector;
			}
			//return new SelectorExpressionTree((string)source, typeDescriptorContext);
			throw new ArgumentException("__SR.Get(\"CannotConvertType\", source.GetType().FullName, typeof(SelectorExpressionTree))");
		}

		[SecurityCritical]
		public override object ConvertTo(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value, Type destinationType)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			if (null == destinationType)
				throw new ArgumentNullException(nameof(destinationType));
			if (!(value is TextualStyle))
			{
				throw new ArgumentException(@"Unexpected parameter type. Must be CornerRadiusScale", nameof(value));
			}
			var textualStyle = (TextualStyle)value;
			if (destinationType == typeof (string))
				return textualStyle.ToString();

			throw new ArgumentException(@"CannotConvertType", nameof(value));
		}


		//public override object ConvertTo(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value, Type destinationType)
		//{
		//	if (value == null)
		//		throw new ArgumentNullException(nameof(value));

		//	if (null == destinationType)
		//		throw new ArgumentNullException(nameof(destinationType));

		//	if (destinationType != typeof(string))
		//		throw new ArgumentException(__SR.Get("CannotConvertType", typeof(PropertyPath), destinationType.FullName));

		//	var selectorExpressionTree = value as SelectorExpressionTree;
		//	if (selectorExpressionTree == null)
		//		throw new ArgumentException(__SR.Get("UnexpectedParameterType", value.GetType(), typeof(SelectorExpressionTree)), nameof(value));



		//	return new SelectorExpressionTree();


		//}
	}
}
/*{
	public sealed class TextualStyleConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext typeDescriptorContext, Type sourceType)
		{
			return sourceType == typeof(string);
		}

		public override bool CanConvertTo(ITypeDescriptorContext typeDescriptorContext, Type destinationType)
		{
			return destinationType == typeof(string);
		}

		public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (source is string)
			{
				var parser = new TextualStyleParser((string)source);
				var selector = parser.Parse();
				return selector;
			}
			//return new SelectorExpressionTree((string)source, typeDescriptorContext);
			throw new ArgumentException("__SR.Get(\"CannotConvertType\", source.GetType().FullName, typeof(SelectorExpressionTree))");
		}

		//public override object ConvertTo(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value, Type destinationType)
		//{
		//	if (value == null)
		//		throw new ArgumentNullException(nameof(value));

		//	if (null == destinationType)
		//		throw new ArgumentNullException(nameof(destinationType));

		//	if (destinationType != typeof(string))
		//		throw new ArgumentException(__SR.Get("CannotConvertType", typeof(PropertyPath), destinationType.FullName));

		//	var selectorExpressionTree = value as SelectorExpressionTree;
		//	if (selectorExpressionTree == null)
		//		throw new ArgumentException(__SR.Get("UnexpectedParameterType", value.GetType(), typeof(SelectorExpressionTree)), nameof(value));



		//	return new SelectorExpressionTree();


		//}
	}
}
*/
