using System;
using System.ComponentModel;
using Core.Markup.TypeConverters;

namespace Core.Layout
{
	[TypeConverter(typeof(PercentageConverter))]
	public class Percentage// : IComparable, IFormattable, IConvertible, IComparable<double>, IEquatable<double>
	{
		protected bool Equals(Percentage other)
		{
			return _value.Equals(other._value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((Percentage)obj);
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}


		public static readonly Percentage MinValue = new Percentage(0d);

		public static readonly Percentage MaxValue = new Percentage(double.MaxValue);


		public static bool operator ==(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value.Equals(right.Value);
		}

		public static bool operator !=(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return !left.Value.Equals(right.Value);
		}

		public static bool operator <(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value < right.Value;
		}

		public static bool operator >(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value > right.Value;
		}

		public static bool operator <=(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value <= right.Value;
		}
		public static bool operator >=(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value >= right.Value;
		}

		private double _value;
		public double Value
		{
			get { return _value; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(value), value,
						@"Value must be greater than or equal to 0");
				_value = value;
			}
		}

		public Percentage(double value)
		{
			Value = value;
		}
	}
}
