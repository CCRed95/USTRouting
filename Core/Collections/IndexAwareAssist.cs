using System.Windows;
using Core.Helpers.DependencyHelpers;

namespace Core.Collections
{
	public static class IndexAwareAssist
	{
		public static readonly DependencyProperty IndexAwareDataProperty =
			DP.Attach<IndexAwareData>(typeof (IndexAwareAssist), new FrameworkPropertyMetadata(new IndexAwareData()));

		public static IndexAwareData GetIndexAwareData(DependencyObject i) => i.Get<IndexAwareData>(IndexAwareDataProperty);
		public static void SetIndexAwareData(DependencyObject i, IndexAwareData v) => i.Set(IndexAwareDataProperty, v);

	}
}
