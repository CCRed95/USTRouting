using System.Windows;
using System.Windows.Controls;
using Core.Helpers.DependencyHelpers;

namespace Core.Controls
{
	public class ArbitraryDataScope : Grid 
	{
		public static readonly DependencyProperty ArbitraryDataContextProperty = DP.Register(
			new Meta<ArbitraryDataScope, object>());

		public object ArbitraryDataContext
		{
			get { return GetValue(ArbitraryDataContextProperty); }
			set { SetValue(ArbitraryDataContextProperty, value); }
		}
	}
}
