using System;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Data;
using Core.Helpers;

namespace Core.Extensions
{
	public static class BindingExtensions
	{
		public static BindingPrefix Bind<TObject>(this TObject @this, Expression<Func<TObject, object>> propertyExpression)
			where TObject : DependencyObject
    {
			var name = propertyExpression.GetMemberInfo().Name;
			var dependencyProperty = @this.GetType().GetStaticFieldValue<DependencyProperty>($"{name}Property");
			return @this.Bind(dependencyProperty);
    }
		public static BindingPrefix Bind(this DependencyObject @this, DependencyProperty property)
		{
			return new BindingPrefix(@this, property);
		}


		public static BindingExpressionBase To(this BindingPrefix @this, DependencyProperty property2, object source)
		{
			var binding = new Binding(property2.Name) { Source = source };
			return BindingOperations.SetBinding(@this.DependencyObject, @this.DependencyProperty, binding);
		}
		public static BindingExpressionBase To(this BindingPrefix @this, string path, object source)
		{
			var binding = new Binding
			{
				Source = source,
				Path = new PropertyPath(path)
			};
			return BindingOperations.SetBinding(@this.DependencyObject, @this.DependencyProperty, binding);
		}
		public static BindingExpressionBase To2<TObject>(this BindingPrefix @this, TObject source, Expression<Func<TObject, object>> pathExpression)
			where TObject : DependencyObject
		{
			var name = pathExpression.GetMemberInfo().Name;
			
			return @this.To2(source, name);
		}
		public static BindingExpressionBase To2(this BindingPrefix @this, DependencyObject source, string path)
		{
			var binding = new Binding
			{
				Source = source,
				Path = new PropertyPath(path)
			};
			return BindingOperations.SetBinding(@this.DependencyObject, @this.DependencyProperty, binding);
		}
		public static BindingExpressionBase To(this BindingPrefix @this, string path, RelativeSource relativeSource)
		{
			var binding = new Binding
			{
				RelativeSource = relativeSource,
				Path = new PropertyPath(path)
			};
			return BindingOperations.SetBinding(@this.DependencyObject, @this.DependencyProperty, binding);
		}


		//public static BindingExpressionBase Bind(this DependencyObject @this, 
		//	DependencyProperty property, string path)
		//{
		//	return BindingOperations.SetBinding(@this, property, new Binding { Source = textualStyle });
		//}
		//public static BindingExpressionBase Bind(this DependencyObject @this, 
		//	DependencyProperty property, object source, DependencyProperty property2)
		//{
		//	return BindingOperations.SetBinding(@this, property, new Binding(property2.Name) { Source = source });
		//}
		//public static BindingExpressionBase Bind(this DependencyObject @this, 
		//	DependencyProperty property, string path)
		//{
		//	return BindingOperations.SetBinding(@this, property, new Binding { Source = textualStyle });
		//}
	}
	public class BindingPrefix
	{
		public DependencyObject DependencyObject { get; }
		public DependencyProperty DependencyProperty { get; }

		public BindingPrefix(DependencyObject dependencyObject, DependencyProperty dependencyProperty)
		{
			DependencyObject = dependencyObject;
			DependencyProperty = dependencyProperty;
		}
	}
	public static class Find
	{
		public static RelativeSource TemplatedParent = new RelativeSource(RelativeSourceMode.TemplatedParent);

		public static RelativeSource Ancestor = new RelativeSource(RelativeSourceMode.FindAncestor);

		public static RelativeSource PreviousData = new RelativeSource(RelativeSourceMode.PreviousData);
		
		public static RelativeSource Self = new RelativeSource(RelativeSourceMode.Self);

		public static RelativeSource AncestorAt<TAncestor>(int level = 1) where TAncestor : FrameworkElement
		{
			return new RelativeSource(RelativeSourceMode.FindAncestor, typeof(TAncestor), level);
		}
		
		
	}
}
