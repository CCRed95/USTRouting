using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Core.Extensions
{
	public static class IEnumerableExtensions
	{
		public static BindableCollection<TElement> ToBindable<TElement>(this IEnumerable<TElement> @this)
		{
			return new BindableCollection<TElement>(@this.ToArray());
		}
	}
}
