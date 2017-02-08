using System;
using System.Collections.Generic;
using System.Globalization;
using Core.Markup;

namespace Material.Converters
{
	/// <summary>
	/// From ButchersBoy's material design toolkit
	/// 
	/// Help us format the content of a header button in a calendar.
	/// </summary>
	/// <remarks>
	/// Expected items, in the following order:
	///     1) DateTime Calendar.DisplayDate
	///     2) DateTime? Calendar.SelectedDate
	/// </remarks>

	public class CalendarDateCoalesceConverter : XAMLConverter<DateTime, DateTime?, NULLPARAM, DateTime?>
	{
		public override DateTime? Convert(DateTime date1, DateTime? date2, NULLPARAM param)
		{
			return date2 ?? date1;
		}
	}
}