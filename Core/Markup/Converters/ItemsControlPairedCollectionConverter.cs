using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Core.Markup.Converters
{
	public class ItemsControlPairedCollectionConverter : XAMLConverter<ItemsControl, NULLPARAM, IEnumerable<Tuple<object, ContentPresenter>>>
	{
		public override IEnumerable<Tuple<object, ContentPresenter>> Convert(ItemsControl arg1, NULLPARAM param)
		{
			var collection = new List<Tuple<object, ContentPresenter>>();

			foreach (var item in arg1.Items)
			{

			}
			return collection;
		}

		//private ContentPresenter GetVisual(ItemsControl itemsControl, string name)
		//{
		//	var itemsControl = context.RootExecutionContext as ItemsControl;
		//	if (itemsControl == null)
		//		throw new NotSupportedException("Can only execute FindNameInItemsControlSelector on an ItemsControl.");

		//	var frameworkElement = parent as FrameworkElement;
		//	if (frameworkElement == null)
		//		throw new NotSupportedException("Parent selector must be FrameworkElement.");

		//	frameworkElement.ApplyTemplate();
		//	itemsControl.ApplyTemplate();

		//	var targetElement = itemsControl.ItemTemplate.FindName(TargetName, frameworkElement);
		//	return targetElement;
		//}
	}
}
