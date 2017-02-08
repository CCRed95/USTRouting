using System;
using System.Windows;
using Core.Exceptions;

namespace Core.Helpers.DependencyHelpers
{
	public class DPChangedEventArgs<PT>
	{
		public DependencyProperty Property;
		public PT OldValue { get; }
		public PT NewValue { get; }

		public DPChangedEventArgs(DependencyPropertyChangedEventArgs e)
		{
			Property = e.Property;
			try
			{
				OldValue = (PT) e.OldValue;
			}
			catch (Exception GENEX)
			{
				throw new InvalidCastException(FSR.Conversion.CannotDirectCast(e.OldValue, typeof(PT)), GENEX);
			}
			try
			{
				NewValue = (PT) e.NewValue;
			}
			catch (Exception GENEX)
			{
				throw new InvalidCastException(FSR.Conversion.CannotDirectCast(e.NewValue, typeof(PT)), GENEX);
			}
		}
	}
}
