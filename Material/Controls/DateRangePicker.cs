using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Core.Controls;
using Core.Extensions;
using Core.Helpers.DependencyHelpers;
using Core.Helpers.EventHelpers;
using Core.Markup;
using Material.Design;
using Material.Design.Text;
using Material.Static;

namespace Material.Controls
{
	public class CalendarDayData
	{
		private readonly int _activeMonth;

		public DateTime DateTime { get; }

		public int DayNumber => DateTime.Day;

		public int MonthNumber => DateTime.Month;

		public bool IsFuture => DateTime > DateTime.Now;

		public bool IsWithinActiveMonth => MonthNumber == _activeMonth;

		public int DayXPosition { get; }

		public int DayYPosition { get; }


		public CalendarDayData(DateTime dateTime, int activeMonth, int dayXPosition, int dayYPosition)
		{
			DateTime = dateTime;
			_activeMonth = activeMonth;

			DayXPosition = dayXPosition;
			DayYPosition = dayYPosition;
		}
	}
	public class CalendarButtonAssist
	{
		public static readonly DependencyProperty DateTimeProperty =
			DP.Attach<DateTime>(typeof(CalendarButtonAssist), new FrameworkPropertyMetadata());

		public static DateTime GetDateTime(DependencyObject i) => i.Get<DateTime>(DateTimeProperty);
		public static void SetDateTime(DependencyObject i, DateTime v) => i.Set(DateTimeProperty, v);


		public static readonly DependencyProperty CalendarDayDataProperty =
			DP.Attach<CalendarDayData>(typeof (CalendarButtonAssist), new FrameworkPropertyMetadata());

		public static CalendarDayData GetCalendarDayData(DependencyObject i) => i.Get<CalendarDayData>(CalendarDayDataProperty);
		public static void SetCalendarDayData(DependencyObject i, CalendarDayData v) => i.Set(CalendarDayDataProperty, v);
	}
	public class MonthNumberToMonthNameConverter : XAMLConverter<int, NULLPARAM, string>
	{
		public override string Convert(int monthNumber, NULLPARAM param)
		{
			try
			{
				var dateTime = new DateTime(2016, monthNumber, 1);
				return dateTime.ToString("MMMM");
			}
			catch
			{
				return "MONTH";
			}
		}
	}
	public class DateTimeFormatter : XAMLConverter<DateTime?, string, string>
	{
		protected override DateTime? ConvertArg1(object arg)
		{
			if (arg == null)
				return null;
			return (DateTime)arg;

		}

		public override string Convert(DateTime? dateTime, string format)
		{
			if (dateTime == null)
				return "";
			return dateTime.Value.ToString(format).ToUpper();
		}
	}
	public class DateRangePicker : FlexControl
	{
		protected enum CalendarViewStates
		{
			MonthSelectViewState,
			DateSelectViewState
		}

		public static readonly DependencyProperty HeaderDayOfWeekTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1.1)));

		public static readonly DependencyProperty HeaderMonthDayTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1.7)));

		public static readonly DependencyProperty HeaderYearTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1.5)));

		public static readonly DependencyProperty HeaderSelectedDurationTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1.2)));

		public static readonly DependencyProperty CalendarTitleTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1.2) { ForegroundDescriptor = Descriptors.P700Descriptor }));

		public static readonly DependencyProperty CalendarDayOfWeekHeaderTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1) { ForegroundDescriptor = Descriptors.BlackDescriptor }));

		public static readonly DependencyProperty CalendarValidSelectableDayTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1) { ForegroundDescriptor = Descriptors.BlackDescriptor, FontWeight = FontWeights.Heavy }));

		public static readonly DependencyProperty CalendarSelectedDayTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1) { ForegroundDescriptor = Descriptors.WhiteDescriptor, FontWeight = FontWeights.Heavy }));

		public static readonly DependencyProperty CalendarInvalidFutureDayWithinMonthTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(.7) { ForegroundDescriptor = Descriptors.BlackDescriptor, FontWeight = FontWeights.Light }));

		public static readonly DependencyProperty CalendarValidSelectableDayOutsideMonthTextualStyleProperty = DP.Register(
			new Meta<DateRangePicker, TextualStyle>(new TextualStyle(1) { ForegroundDescriptor = Descriptors.BlackDescriptor, FontWeight = FontWeights.Normal }));

		public static readonly DependencyProperty FallbackMaterialSetProperty = DP.Register(
			new Meta<DateRangePicker, MaterialSet>(Palette.Teal));

		public static readonly DependencyProperty StartDateProperty = DP.Register(
			new Meta<DateRangePicker, DateTime?>());

		public static readonly DependencyProperty EndDateProperty = DP.Register(
			new Meta<DateRangePicker, DateTime?>());


		private static readonly DependencyPropertyKey CalendarDisplayDaysPropertyKey = DP.RegisterReadOnly(
			new Meta<DateRangePicker, ObservableCollection<CalendarDayData>>());

		public static readonly DependencyProperty CalendarDisplayDaysProperty = CalendarDisplayDaysPropertyKey.DependencyProperty;


		private static readonly DependencyPropertyKey IsSelectingPropertyKey = DP.RegisterReadOnly(
			new Meta<DateRangePicker, bool>());

		public static readonly DependencyProperty IsSelectingProperty = IsSelectingPropertyKey.DependencyProperty;

		private static readonly DependencyPropertyKey ActiveMonthNumberPropertyKey = DP.RegisterReadOnly(
			new Meta<DateRangePicker, int>());

		public static readonly DependencyProperty ActiveMonthNumberProperty = ActiveMonthNumberPropertyKey.DependencyProperty;


		private static readonly DependencyPropertyKey ActiveYearNumberPropertyKey = DP.RegisterReadOnly(
			new Meta<DateRangePicker, int>());

		public static readonly DependencyProperty ActiveYearNumberProperty = ActiveYearNumberPropertyKey.DependencyProperty;




		public TextualStyle HeaderDayOfWeekTextualStyle
		{
			get { return (TextualStyle)GetValue(HeaderDayOfWeekTextualStyleProperty); }
			set { SetValue(HeaderDayOfWeekTextualStyleProperty, value); }
		}
		public TextualStyle HeaderMonthDayTextualStyle
		{
			get { return (TextualStyle)GetValue(HeaderMonthDayTextualStyleProperty); }
			set { SetValue(HeaderMonthDayTextualStyleProperty, value); }
		}
		public TextualStyle HeaderYearTextualStyle
		{
			get { return (TextualStyle)GetValue(HeaderYearTextualStyleProperty); }
			set { SetValue(HeaderYearTextualStyleProperty, value); }
		}
		public TextualStyle HeaderSelectedDurationTextualStyle
		{
			get { return (TextualStyle)GetValue(HeaderSelectedDurationTextualStyleProperty); }
			set { SetValue(HeaderSelectedDurationTextualStyleProperty, value); }
		}
		public TextualStyle CalendarTitleTextualStyle
		{
			get { return (TextualStyle)GetValue(CalendarTitleTextualStyleProperty); }
			set { SetValue(CalendarTitleTextualStyleProperty, value); }
		}
		public TextualStyle CalendarDayOfWeekHeaderTextualStyle
		{
			get { return (TextualStyle)GetValue(CalendarDayOfWeekHeaderTextualStyleProperty); }
			set { SetValue(CalendarDayOfWeekHeaderTextualStyleProperty, value); }
		}
		public TextualStyle CalendarValidSelectableDayTextualStyle
		{
			get { return (TextualStyle)GetValue(CalendarValidSelectableDayTextualStyleProperty); }
			set { SetValue(CalendarValidSelectableDayTextualStyleProperty, value); }
		}
		public TextualStyle CalendarInvalidFutureDayWithinMonthTextualStyle
		{
			get { return (TextualStyle)GetValue(CalendarInvalidFutureDayWithinMonthTextualStyleProperty); }
			set { SetValue(CalendarInvalidFutureDayWithinMonthTextualStyleProperty, value); }
		}
		public TextualStyle CalendarValidSelectableDayOutsideMonthTextualStyle
		{
			get { return (TextualStyle)GetValue(CalendarValidSelectableDayOutsideMonthTextualStyleProperty); }
			set { SetValue(CalendarValidSelectableDayOutsideMonthTextualStyleProperty, value); }
		}
		public MaterialSet FallbackMaterialSet
		{
			get { return (MaterialSet)GetValue(FallbackMaterialSetProperty); }
			set { SetValue(FallbackMaterialSetProperty, value); }
		}
		public DateTime? StartDate
		{
			get { return (DateTime?)GetValue(StartDateProperty); }
			set { SetValue(StartDateProperty, value); }
		}
		public DateTime? EndDate
		{
			get { return (DateTime?)GetValue(EndDateProperty); }
			set { SetValue(EndDateProperty, value); }
		}
		public ObservableCollection<CalendarDayData> CalendarDisplayDays
		{
			get { return (ObservableCollection<CalendarDayData>)GetValue(CalendarDisplayDaysProperty); }
			protected set { SetValue(CalendarDisplayDaysPropertyKey, value); }
		}
		public bool IsSelecting
		{
			get { return (bool)GetValue(IsSelectingProperty); }
			protected set { SetValue(IsSelectingPropertyKey, value); }
		}
		public int ActiveMonthNumber
		{
			get { return (int)GetValue(ActiveMonthNumberProperty); }
			protected set { SetValue(ActiveMonthNumberPropertyKey, value); }
		}
		public int ActiveYearNumber
		{
			get { return (int)GetValue(ActiveYearNumberProperty); }
			protected set { SetValue(ActiveYearNumberPropertyKey, value); }
		}
		public static readonly DependencyProperty TestPropProperty = DP.Register(
			new Meta<DateRangePicker, bool>());
		public bool TestProp
		{
			get { return (bool) GetValue(TestPropProperty); }
			set { SetValue(TestPropProperty, value); }
		}

		public static readonly RoutedEvent AnimateOutTriggerEvent = EM.Register<DateRangePicker, RoutedEventHandler>(EM.DIRECT);

		public event RoutedEventHandler AnimateOutTrigger
		{
			add { AddHandler(AnimateOutTriggerEvent, value); }
			remove { RemoveHandler(AnimateOutTriggerEvent, value); }
		}

		//[AutoTemplatePart] protected Grid PART_HighlightGrid;
		[AutoTemplatePart]
		protected Label PART_MonthLabel;
		[AutoTemplatePart]
		protected Label PART_BackToDaySelectView;

		[AutoTemplatePart]
		protected Button PART_PreviousMonthButton;
		[AutoTemplatePart]
		protected Button PART_NextMonthButton;

		[AutoTemplatePart]
		protected ItemsControl PART_MonthView;
		[AutoTemplatePart]
		protected StackPanel PART_DayView;

		[AutoTemplatePart]
		protected Button PART_CancelButton;

		

		static DateRangePicker()
		{
			OverrideDefaultStyleKey<DateRangePicker>();
		}

		public DateRangePicker()
		{
			CalendarDisplayDays = new ObservableCollection<CalendarDayData>();
			Loaded += (s, e) => navigateToDate(DateTime.Now);
			//refreshDisplayDaysCollection();
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_MonthLabel.MouseUp += PartDateLabelOnMouseUp;
			PART_BackToDaySelectView.MouseUp += PartBackLabelOnMouseUp;

			PART_PreviousMonthButton.Click += previousMonthButtonClick;
			PART_NextMonthButton.Click += nextMonthButtonClick;

			PART_CancelButton.Click += PartCancelButtonOnClick;

			PART_DayView.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(onCalendarDayButtonClick));
			PART_MonthView.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(onCalendarMonthButtonClick));
		}

		private void PartCancelButtonOnClick(object Sender, RoutedEventArgs Args)
		{
			TestProp = !TestProp;
			RaiseEvent(new RoutedEventArgs(AnimateOutTriggerEvent, this));
		}

		private void nextMonthButtonClick(object Sender, RoutedEventArgs Args)
		{
			if (ActiveMonthNumber >= 12)
			{
				ActiveMonthNumber = 1;
				ActiveYearNumber = ActiveYearNumber + 1;
			}
			else
			{
				ActiveMonthNumber = ActiveMonthNumber + 1;
			}
			navigateToMonth(ActiveMonthNumber, ActiveYearNumber);
		}

		private void previousMonthButtonClick(object Sender, RoutedEventArgs Args)
		{
			if (ActiveMonthNumber <= 1)
			{
				ActiveMonthNumber = 12;
				ActiveYearNumber = ActiveYearNumber - 1;
			}
			else
			{
				ActiveMonthNumber = ActiveMonthNumber - 1;
			}
			navigateToMonth(ActiveMonthNumber, ActiveYearNumber);
		}

		private void PartDateLabelOnMouseUp(object Sender, MouseButtonEventArgs MouseButtonEventArgs)
		{
			this.GoToVisualState(nameof(CalendarViewStates.MonthSelectViewState));
		}
		private void PartBackLabelOnMouseUp(object Sender, MouseButtonEventArgs MouseButtonEventArgs)
		{
			this.GoToVisualState(nameof(CalendarViewStates.DateSelectViewState));
		}

		private void onCalendarDayButtonClick(object Sender, RoutedEventArgs Args)
		{
			var calendarButton = Args.OriginalSource as ToggleButton;

			if (calendarButton?.IsChecked != null && calendarButton.IsChecked.Value)
			{
				var dateTime = CalendarButtonAssist.GetDateTime(calendarButton);
				var calendarDayData = CalendarButtonAssist.GetCalendarDayData(calendarButton);

				if (IsSelecting)
				{
					EndDate = dateTime;
					IsSelecting = false;
				}
				else
				{
					StartDate = dateTime;
					IsSelecting = true;
				}
			}
		}

		private void onCalendarMonthButtonClick(object Sender, RoutedEventArgs Args)
		{
			var calendarButton = Args.OriginalSource as Button;
			if (calendarButton == null)
				throw new Exception();

			var monthNumber = getMonthNumberFromShortName(calendarButton.Content.ToString());
			navigateToMonth(monthNumber, ActiveYearNumber);
			this.GoToVisualState(nameof(CalendarViewStates.DateSelectViewState));
		}

		private void navigateToDate(DateTime dateTime)
		{
			navigateToMonth(dateTime.Month, dateTime.Year);
		}

		private void navigateToMonth(int month, int year)
		{
			CalendarDisplayDays.Clear();

			var now = new DateTime(year, month, 1, 0, 0, 0);
			var dayNumber = now.Day;
			var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
			var daysInCurrentMonth = getDaysInMonth(now.Month, now.Year);
			var lastDayOfMonth = new DateTime(now.Year, now.Month, daysInCurrentMonth);

			var startOffset = (int)firstDayOfMonth.DayOfWeek;
			var endOffset = 6 - startOffset - 1;

			var currentCreationDate = firstDayOfMonth.AddDays(-startOffset);

			var xPosition = 0;
			var yPosition = 0;

			for (var x = 0; x < startOffset; x++)
			{
				if (xPosition >= 6)
				{
					xPosition = -1;
					yPosition++;
				}
				xPosition++;

				CalendarDisplayDays.Add(new CalendarDayData(currentCreationDate, now.Month, xPosition, yPosition));
				currentCreationDate = currentCreationDate.AddDays(1);
			}
			for (var x = 0; x < daysInCurrentMonth; x++)
			{
				if (xPosition >= 6)
				{
					xPosition = -1;
					yPosition++;
				}
				xPosition++;

				CalendarDisplayDays.Add(new CalendarDayData(currentCreationDate, now.Month, xPosition, yPosition));
				currentCreationDate = currentCreationDate.AddDays(1);
			}
			for (var x = 0; x < endOffset; x++)
			{
				if (xPosition >= 6)
				{
					xPosition = -1;
					yPosition++;
				}
				xPosition++;

				CalendarDisplayDays.Add(new CalendarDayData(currentCreationDate, now.Month, xPosition, yPosition));
				currentCreationDate = currentCreationDate.AddDays(1);
			}

			ActiveMonthNumber = now.Month;
			ActiveYearNumber = now.Year;
		}

		private static int getDaysInMonth(int month, int year)
		{
			switch (month)
			{
				case 9:
				case 4:
				case 6:
				case 11:
					return 30;
				case 2:
					{
						if (DateTime.IsLeapYear(year))
							return 29;
						return 28;
					}
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					return 31;
				default:
					throw new ArgumentOutOfRangeException(nameof(month));
			}
		}

		private static int getMonthNumberFromShortName(string shortName)
		{
			switch (shortName.ToUpper())
			{
				case "JAN":
					return 1;
				case "FEB":
					return 2;
				case "MAR":
					return 3;
				case "APR":
					return 4;
				case "MAY":
					return 5;
				case "JUN":
					return 6;
				case "JUL":
					return 7;
				case "AUG":
					return 8;
				case "SEP":
					return 9;
				case "OCT":
					return 10;
				case "NOV":
					return 11;
				case "DEC":
					return 12;
				default:
					throw new ArgumentOutOfRangeException(nameof(shortName));
			}
		}
	}
}
