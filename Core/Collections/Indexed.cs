namespace Core.Collections
{
	public abstract class Indexed
	{
		public abstract object ValueBase { get; }
		public int Index { get; protected set; }
		public int Count { get; protected set; }

		public bool IsOnlyElement => Count == 1;
		public bool IsFirstElement => Index == 0;
		public bool IsLastElement => Index == Count - 1;

		protected Indexed(int index, int count)
		{
			Index = index;
			Count = count;
		} 
	}
	public class Indexed<T> : Indexed
	{
		public T Value { get; }
		public override object ValueBase => Value;
		
		public Indexed(T value, int index, int count) : base(index, count)
		{
			Value = value;
		}
	}
}
