using System;

namespace Core.Data
{
	public class Ref<TValue>
	{
		private readonly Func<TValue> _accessor;
		
		private TValue _cachedValue;

		private bool _hasBeenEvaluated;


		public Ref(Func<TValue> accessor)
		{
			_accessor = accessor;
		}

		public static implicit operator TValue(Ref<TValue> @this)
		{
			return @this.Value;
		}

		public TValue Value
		{
			get
			{
				if (_hasBeenEvaluated)
				{
					return _cachedValue;
				}
				_cachedValue = _accessor();
				_hasBeenEvaluated = true;
				return _cachedValue;
			}
		}
	}

	public class Ref<TKey, TValue>
	{
		private readonly Func<TKey, TValue> _accessor;

		private readonly TKey _key;

		private TValue _cachedValue;

		private bool _hasBeenEvaluated;


		public Ref(TKey key, Func<TKey, TValue> accessor)
		{
			_key = key;
			_accessor = accessor;
		}

		public static implicit operator TValue(Ref<TKey, TValue> @this)
		{
			return @this.Value;
		} 

		public TValue Value
		{
			get
			{
				if (_hasBeenEvaluated)
				{
					return _cachedValue;
				}
				_cachedValue = _accessor(_key);
				_hasBeenEvaluated = true;
				return _cachedValue;
			}
		}
	}
}
