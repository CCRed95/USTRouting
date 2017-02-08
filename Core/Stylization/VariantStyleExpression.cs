using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Core.Collections;

namespace Core.Stylization
{
	public class VariantStyleExpression
	{
		protected Style defaultStyle { get; set; }
		protected List<StyleVariant> variants;

		public VariantStyleExpression(Style _defaultStyle, params StyleVariant[] _variants)
		{
			defaultStyle = _defaultStyle;
			variants = _variants.ToList();
		}

		public void AddVariant(StyleVariant variant)
		{
			variants.Add(variant);
		}

		public Style GetVariantStyle()
		{
			var compoundStyle = new Style
			{
				BasedOn = defaultStyle,
				TargetType = defaultStyle.TargetType
			};
			foreach (var variant in variants)
			{
				foreach (var variantSetter in variant.Setters.OfType<Setter>())
				{
					compoundStyle.Setters.Add(new Setter
					{
						Property = variantSetter.Property,
						Value = variantSetter.Value
					});
				}
			}
			return compoundStyle;
		}
	}
}
