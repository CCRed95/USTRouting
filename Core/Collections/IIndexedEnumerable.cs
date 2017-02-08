using System.Collections.Generic;

namespace Core.Collections
{
	public interface IIndexedEnumerable<T> : IEnumerable<Indexed<T>>
	{
	}
}
