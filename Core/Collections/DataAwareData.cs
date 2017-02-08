using System.Windows;
using Core.Helpers.DependencyHelpers;

namespace Core.Collections
{
	public class DataAwareData : Freezable
	{
		public static readonly DependencyProperty IndexProperty = DP.Register(
			new Meta<DataAwareData, int>());

		public static readonly DependencyProperty IsAdjacentToLargerLeftBarProperty = DP.Register(
			new Meta<DataAwareData, bool>());

		public static readonly DependencyProperty IsAdjacentToLargerRightBarProperty = DP.Register(
			new Meta<DataAwareData, bool>());

		public static readonly DependencyProperty IsAdjacentToSimilarLeftBarProperty = DP.Register(
			new Meta<DataAwareData, bool>());

		public static readonly DependencyProperty IsAdjacentToSimilarRightBarProperty = DP.Register(
			new Meta<DataAwareData, bool>());


		public int Index
		{
			get { return (int)GetValue(IndexProperty); }
			set { SetValue(IndexProperty, value); }
		}
		public bool IsAdjacentToSimilarLeftBar
		{
			get { return (bool) GetValue(IsAdjacentToSimilarLeftBarProperty); }
			set { SetValue(IsAdjacentToSimilarLeftBarProperty, value); }
		}
		public bool IsAdjacentToSimilarRightBar
		{
			get { return (bool) GetValue(IsAdjacentToSimilarRightBarProperty); }
			set { SetValue(IsAdjacentToSimilarRightBarProperty, value); }
		}
		public bool IsAdjacentToLargerLeftBar
		{
			get { return (bool) GetValue(IsAdjacentToLargerLeftBarProperty); }
			set { SetValue(IsAdjacentToLargerLeftBarProperty, value); }
		}
		public bool IsAdjacentToLargerRightBar
		{
			get { return (bool) GetValue(IsAdjacentToLargerRightBarProperty); }
			set { SetValue(IsAdjacentToLargerRightBarProperty, value); }
		}

		protected override Freezable CreateInstanceCore()
		{
			return new DataAwareData();
		}
	}
}
