using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Core.Controls;
using Core.Extensions;
using Core.Helpers.DependencyHelpers;
using Core.Helpers.EventHelpers;

namespace Material.Controls
{
	public class TimeSelector : FlexControl
	{
		public static readonly DependencyProperty CurrentTimeProperty = DP.Register(
			new Meta<TimeSelector, TimeSpan>(TimeSpan.Zero, ChangedCallback));
		public TimeSpan CurrentTime
		{
			get { return (TimeSpan)GetValue(CurrentTimeProperty); }
			set { SetValue(CurrentTimeProperty, value); }
		}

		public static readonly RoutedEvent TimeChangedEvent = EM.Register<TimeSelector, RoutedEventHandler>(EM.BUBBLE);
		public event RoutedEventHandler TimeChanged
		{
			add { AddHandler(TimeChangedEvent, value); }
			remove { RemoveHandler(TimeChangedEvent, value); }
		}

		private static void ChangedCallback(TimeSelector i, DPChangedEventArgs<TimeSpan> e)
		{
			i.RaiseEvent(new RoutedEventArgs(TimeChangedEvent, e.NewValue));
		}

		[AutoTemplatePart]
		protected Button PART_hourarrowup;
		[AutoTemplatePart]
		protected Label PART_hourtop;
		[AutoTemplatePart]
		protected Label PART_hour;
		[AutoTemplatePart]
		protected Label PART_hourbottom;
		[AutoTemplatePart]
		protected Button PART_hourarrowdown;

		[AutoTemplatePart]
		protected Button PART_minarrowup;
		[AutoTemplatePart]
		protected Label PART_mintop;
		[AutoTemplatePart]
		protected Label PART_min;
		[AutoTemplatePart]
		protected Label PART_minbottom;
		[AutoTemplatePart]
		protected Button PART_minarrowdown;

		[AutoTemplatePart]
		protected Button PART_periodarrowup;
		[AutoTemplatePart]
		protected Label PART_periodtop;
		[AutoTemplatePart]
		protected Label PART_period;
		[AutoTemplatePart]
		protected Label PART_periodbottom;
		[AutoTemplatePart]
		protected Button PART_periodarrowdown;


		static TimeSelector()
		{
			OverrideDefaultStyleKey<TimeSelector>();
		}

		public TimeSelector()
		{
			Loaded += OnLoaded;
		}

		private void OnLoaded(object Sender, RoutedEventArgs Args)
		{
			updateTime();
		}

		private void updateTime()
		{
			var hourValue = Convert.ToInt32(PART_hour.Content);
			var minuteValue = Convert.ToInt32(PART_min.Content);
			var periodValue = PART_period.Content;
			if (periodValue.Equals("PM"))
			{
				if (hourValue != 12)
				{
					hourValue += 12;
				}
			}
			else
			{
				if (hourValue == 12)
				{
					hourValue = 0;
				}
			}
			var timeSpan = new TimeSpan(hourValue, minuteValue, 0);
			CurrentTime = timeSpan;
			
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			PART_hourarrowup.Click += hourIndexUp;
			PART_hourarrowdown.Click += hourIndexDown;
			PART_minarrowup.Click += minuteIndexUp;
			PART_minarrowdown.Click += minuteIndexDown;
			PART_periodarrowup.Click += periodIndexUp;
			PART_periodarrowdown.Click += periodIndexDown;
		}

		private void hourIndexUp(object s, RoutedEventArgs Args)
		{
			var value = Convert.ToInt32(PART_hour.Content) - 1;
			PART_hourtop.Content = (value - 1).RollRange(1, 12);
			PART_hour.Content = value.RollRange(1, 12);
			PART_hourbottom.Content = (value + 1).RollRange(1, 12);
			updateTime();
		}
		private void hourIndexDown(object s, RoutedEventArgs Args)
		{
			var value = Convert.ToInt32(PART_hour.Content) + 1;
			PART_hourtop.Content = (value - 1).RollRange(1, 12);
			PART_hour.Content = value.RollRange(1, 12);
			PART_hourbottom.Content = (value + 1).RollRange(1, 12);
			updateTime();
		}

		private void minuteIndexUp(object s, RoutedEventArgs Args)
		{
			var value = Convert.ToInt32(PART_min.Content) - 1;
			PART_mintop.Content = (value - 1).RollRange(0, 59).FixedDigit(2);
			PART_min.Content = value.RollRange(0, 59).FixedDigit(2);
			PART_minbottom.Content = (value + 1).RollRange(0, 59).FixedDigit(2);
			updateTime();
		}
		private void minuteIndexDown(object s, RoutedEventArgs Args)
		{
			var value = Convert.ToInt32(PART_min.Content) + 1;
			PART_mintop.Content = (value - 1).RollRange(0, 59).FixedDigit(2);
			PART_min.Content = value.RollRange(0, 59).FixedDigit(2);
			PART_minbottom.Content = (value + 1).RollRange(0, 59).FixedDigit(2);
			updateTime();
		}

		private void periodIndexUp(object s, RoutedEventArgs Args)
		{
			if (PART_period.Content.Equals("AM"))
			{
				PART_periodtop.Content = "AM";
				PART_period.Content = "PM";
				PART_periodbottom.Content = "";
				updateTime();
			}
		}
		private void periodIndexDown(object s, RoutedEventArgs Args)
		{
			if (PART_period.Content.Equals("PM"))
			{
				PART_periodtop.Content = "";
				PART_period.Content = "AM";
				PART_periodbottom.Content = "PM";
				updateTime();
			}
		}
	}
}
