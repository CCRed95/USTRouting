using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core.Collections
{
	public class IndexedCollection<T> : IIndexedEnumerable<T>
	{
		public IEnumerable<T> Source { get; protected set; }

		public IndexedCollection(IEnumerable<T> source)
		{
			Source = source;
		}

		public IEnumerator<Indexed<T>> GetEnumerator()
		{
			var index = -1;
			var sourceList = Source.ToList();
			var sourceCount = sourceList.Count;
			foreach (var item in sourceList)
			{
				index++;
				yield return new Indexed<T>(item, index, sourceCount);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	
}
