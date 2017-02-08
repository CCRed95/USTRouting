using System.Windows;
using System.Windows.Controls;

namespace Core.Stylization
{
	public abstract class VariantTemplateProvider<T> : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			var i = (T) item;
			var variantTemplateExpression = DetermineVariantExpression(i, container);
			var variantStyle = variantTemplateExpression.GetVariantStyle();
			return CreateTemplate(variantStyle);  
		}

		public abstract VariantStyleExpression DetermineVariantExpression(T item, DependencyObject container);

		public abstract DataTemplate CreateTemplate(Style variantStyle);

	}
}
