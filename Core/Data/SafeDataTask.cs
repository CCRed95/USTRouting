using System;
namespace Core.Data
{
	public class SafeDataTask<TResult>
	{
		protected Func<TResult> _func;
		 
		public bool TryExec(out TResult result)
		{
			try
			{
				var value = _func();
				result = value;
				return true;
			}
			catch
			{
				result = default(TResult);
				return false;
			}
		}

		public SafeDataTask(Func<TResult> func)
		{
			_func = func;
		}
	}
}

