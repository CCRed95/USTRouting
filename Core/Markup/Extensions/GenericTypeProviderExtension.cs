﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using Core.Extensions;

namespace Core.Markup.Extensions
{
	[MarkupExtensionReturnType(typeof(Type))]
	public class GenericTypeProviderExtension : MarkupExtension
	{
		public GenericTypeProviderExtension() { }

		public GenericTypeProviderExtension(string typeName)
		{
			TypeName = typeName;
		}

		public GenericTypeProviderExtension(Type type)
		{
			Type = type;
		}

		public string TypeName { get; set; }
		public Type Type { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Type == null)
			{
				var typeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;
				if (typeResolver == null) throw new InvalidOperationException("EDF Type markup extension used without XAML context");
				if (TypeName == null) throw new InvalidOperationException("EDF Type markup extension used without Type or TypeName");
				Type = ResolveGenericTypeName(TypeName, (name) =>
				{
					Type result = typeResolver.Resolve(name);
					if (result == null) throw new Exception("EDF Type markup extension could not resolve type " + name);
					return result;
				});
			}
			return Type;
		}

		public static Type ResolveGenericTypeName(string name, Func<string, Type> resolveSimpleName)
		{
			if (name.Contains('{'))
				name = name.Replace('{', '<').Replace('}', '>');  // Note:  For convenience working with XAML, we allow {} instead of <> for generic type parameters

			if (name.Contains('<'))
			{
				var match = _genericTypeRegex.Match(name);
				if (match.Success)
				{
					Type[] typeArgs = (
						from arg in match.Groups["typeArgs"].Value.SplitOutsideParenthesis(',')
						select ResolveGenericTypeName(arg, resolveSimpleName)
						).ToArray();
					string genericTypeName = match.Groups["genericTypeName"].Value + "`" + typeArgs.Length;
					Type genericType = resolveSimpleName(genericTypeName);
					if (genericType != null && !typeArgs.Contains(null))
						return genericType.MakeGenericType(typeArgs);
				}
			}
			return resolveSimpleName(name);
		}
		static Regex _genericTypeRegex = new Regex(@"^(?<genericTypeName>\w+)<(?<typeArgs>\w+(,\w+)*)>$");

	}
}
