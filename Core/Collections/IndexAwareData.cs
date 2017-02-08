using System.Windows;
using Core.Helpers.DependencyHelpers;

namespace Core.Collections
{
	public class IndexAwareData : Freezable
	{
		public static readonly DependencyProperty IndexProperty = DP.Register(
			new Meta<IndexAwareData, int>());

		public static readonly DependencyProperty IsFirstProperty = DP.Register(
			new Meta<IndexAwareData, bool>());

		public static readonly DependencyProperty IsInnerProperty = DP.Register(
			new Meta<IndexAwareData, bool>());

		public static readonly DependencyProperty IsLastProperty = DP.Register(
			new Meta<IndexAwareData, bool>());

		public static readonly DependencyProperty IsSingleProperty = DP.Register(
			new Meta<IndexAwareData, bool>());


		public int Index
		{
			get { return (int) GetValue(IndexProperty); }
			set { SetValue(IndexProperty, value); }
		}
		public bool IsFirst
		{
			get { return (bool) GetValue(IsFirstProperty); }
			set { SetValue(IsFirstProperty, value); }
		}
		public bool IsInner
		{
			get { return (bool) GetValue(IsInnerProperty); }
			set { SetValue(IsInnerProperty, value); }
		}
		public bool IsLast
		{
			get { return (bool) GetValue(IsLastProperty); }
			set { SetValue(IsLastProperty, value); }
		}
		public bool IsSingle
		{
			get { return (bool) GetValue(IsSingleProperty); }
			set { SetValue(IsSingleProperty, value); }
		}
		protected override Freezable CreateInstanceCore()
		{
			return new IndexAwareData();
		}
	}
}
