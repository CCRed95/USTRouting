using System;
using System.Collections.Generic;
using Core.Exceptions;

namespace Core.Collections
{
	public static class CollectionHelpers
	{
		public static int TryAdd<T>(T value, ref IList<T> collection)
		{
			if (collection.IsReadOnly)
				throw new NotSupportedException(FSR.Collections.CannotAddToReadOnly(value));
			collection.Add(value);
			return collection.Count;
		}

		public static void TryInsert<T>(int index, T value, ref IList<T> collection)
		{
			if (collection.IsReadOnly)
				throw new NotSupportedException(FSR.Collections.CannotInsertIntoReadOnly(value));
			collection.Insert(index, value);
		}

		public static bool TryRemove<T>(T value, ref IList<T> collection)
		{
			if (collection.IsReadOnly)
				throw new NotSupportedException(FSR.Collections.CannotRemoveFromReadOnly(value));
			if (!collection.Contains(value))
				return false;
			collection.Remove(value);
			return true;
		}

		public static void TryRemoveAt<T>(int index, ref IList<T> collection)
		{
			if (collection.IsReadOnly)
				throw new NotSupportedException(FSR.Collections.CannotRemoveAtFromReadOnly(index));
			if (collection.Count >= index)
				throw new IndexOutOfRangeException(FSR.Collections.IndexOutOfRange(index));
			collection.RemoveAt(index);
		}
	}
}