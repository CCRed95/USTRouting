using System.Windows;
using Core.Helpers.DependencyHelpers;

namespace Core.Collections
{
	public static class DataAwareAssist
	{
		public static readonly DependencyProperty DataAwareDataProperty =
			DP.Attach<DataAwareData>(typeof (DataAwareAssist), new FrameworkPropertyMetadata(new DataAwareData()));

		public static DataAwareData GetDataAwareData(DependencyObject i) => i.Get<DataAwareData>(DataAwareDataProperty);
		public static void SetDataAwareData(DependencyObject i, DataAwareData v) => i.Set(DataAwareDataProperty, v);
	}
}
