using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using Core.Extensions;
using Core.Helpers.DependencyHelpers;

namespace Material.Controls.Ripples
{
	public static class RippleBinder
	{

		public static readonly DependencyProperty TrackerProperty =
			DP.Attach<NewRippleTracker>(typeof(RippleBinder), new FrameworkPropertyMetadata(onTrackerChanged));

		private static void onTrackerChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var tracker = (NewRippleTracker) e.NewValue;
			tracker.Associate((FrameworkElement)o);

		}

		public static NewRippleTracker GetTracker(DependencyObject i) => i.Get<NewRippleTracker>(TrackerProperty);
		public static void SetTracker(DependencyObject i, NewRippleTracker v) => i.Set(TrackerProperty, v);

	}
	public class NewRippleTracker : DependencyObject
	{
		private FrameworkElement associatedObject;
		public FrameworkElement AssociatedObject
		{
			get { return associatedObject; }
			private set
			{
				associatedObject = value;
				this.updateTarget();
			} 
		}

		public void Associate(FrameworkElement element)
		{
			AssociatedObject = element;
		}

		//public static readonly DependencyProperty SourceObjectProperty = DP.Register(
		//	new Meta<NewRippleTracker, object>(null, onSourceObjectChanged));

		public static readonly DependencyProperty EventNameProperty = DP.Register(
			new Meta<NewRippleTracker, string>(null, onEventNameChanged));

	


		//public object SourceObject
		//{
		//	get { return (object) GetValue(SourceObjectProperty); }
		//	set { SetValue(SourceObjectProperty, value); }
		//}
		public string EventName
		{
			get { return (string) GetValue(EventNameProperty); }
			set { SetValue(EventNameProperty, value); }
		}


		//private static void onSourceObjectChanged(NewRippleTracker i, DPChangedEventArgs<object> e)
		//{
		//	i.updateTarget();
		//}
		private static void onEventNameChanged(NewRippleTracker i, DPChangedEventArgs<string> e)
		{
			i.updateTarget();
		}

		private void updateTarget()
		{
			if (!EventName.IsNullOrEmpty() && AssociatedObject != null)
			{
				var @event = AssociatedObject.GetType().GetEvent(EventName);
				if(@event == null)
					throw new ArgumentException($"Could not find event \'{EventName}\'on source object \'{AssociatedObject.GetType().Name}\'");

				if (!IsValidEvent(@event))
					throw new ArgumentException($"EventTriggerBaseInvalidEventExceptionMessage {EventName}, {associatedObject.GetType().Name}");
			
				eventHandlerMethodInfo = typeof(NewRippleTracker).GetMethod("OnEventImpl", BindingFlags.Instance | BindingFlags.NonPublic);
				@event.AddEventHandler(AssociatedObject, Delegate.CreateDelegate(@event.EventHandlerType, this, eventHandlerMethodInfo));

			}
		}
		private MethodInfo eventHandlerMethodInfo;


		private static bool IsValidEvent(EventInfo eventInfo)
		{
			var eventHandlerType = eventInfo.EventHandlerType;
			if (!typeof(Delegate).IsAssignableFrom(eventInfo.EventHandlerType))
				return false;
			var parameters = eventHandlerType.GetMethod("Invoke").GetParameters();
			if (parameters.Length == 2 && typeof(object).IsAssignableFrom(parameters[0].ParameterType))
				return typeof(EventArgs).IsAssignableFrom(parameters[1].ParameterType);
			return false;
		}
		

		protected void OnEventImpl(object s, EventArgs e)
		{
			var mousePos = Mouse.GetPosition(AssociatedObject);
			RippleFinal.SetMousePosition(AssociatedObject, mousePos);
		}
	}
	public class RippleMouseTrackerOLD : Behavior<FrameworkElement>
	{
		public static readonly DependencyProperty SourceObjectProperty = DP.Register(
			new Meta<RippleMouseTrackerOLD, object>(null, onSourceObjectChanged ));
		
		public static readonly DependencyProperty EventNameProperty = DP.Register(
			new Meta<RippleMouseTrackerOLD, string>(null, onEventNameChanged));


		public object SourceObject
		{
			get { return GetValue(SourceObjectProperty); }
			set { SetValue(SourceObjectProperty, value); }
		}

		public string EventName
		{
			get { return (string)GetValue(EventNameProperty); }
			set { SetValue(EventNameProperty, value); }
		}


		private static void onSourceObjectChanged(RippleMouseTrackerOLD e, DPChangedEventArgs<object> args)
		{
			if (e.SourceObject != null && !e.EventName.IsNullOrWhiteSpace())
			{
				e.registerEventHandler(e.SourceObject, e.EventName);
			}
		}
		private static void onEventNameChanged(RippleMouseTrackerOLD e, DPChangedEventArgs<string> args)
		{
			if (e.SourceObject != null && !e.EventName.IsNullOrWhiteSpace())
			{
				e.registerEventHandler(e.SourceObject, e.EventName);
			}
		}

		private MethodInfo eventHandlerMethodInfo;

		private void registerEventHandler(object obj, string eventName)
		{
			var @event = obj.GetType().GetEvent(eventName);
			if (@event == null)
			{
				if (SourceObject != null)
					throw new ArgumentException($"EventTriggerCannotFindEventNameExceptionMessage {eventName}, {obj.GetType().Name}");
			}
			else if (!IsValidEvent(@event))
			{
				if (SourceObject != null)
					throw new ArgumentException($"EventTriggerBaseInvalidEventExceptionMessage {eventName}, {obj.GetType().Name}");
			}
			else
			{
				eventHandlerMethodInfo = typeof(RippleMouseTrackerOLD).GetMethod("OnEventImpl", BindingFlags.Instance | BindingFlags.NonPublic);
				@event.AddEventHandler(obj, Delegate.CreateDelegate(@event.EventHandlerType, this, eventHandlerMethodInfo));
			}
		}

		private static bool IsValidEvent(EventInfo eventInfo)
		{
			var eventHandlerType = eventInfo.EventHandlerType;
			if (!typeof(Delegate).IsAssignableFrom(eventInfo.EventHandlerType))
				return false;
			var parameters = eventHandlerType.GetMethod("Invoke").GetParameters();
			if (parameters.Length == 2 && typeof(object).IsAssignableFrom(parameters[0].ParameterType))
				return typeof(EventArgs).IsAssignableFrom(parameters[1].ParameterType);
			return false;
		}



		protected void OnEventImpl(object s, EventArgs e)
		{
			var mousePos = Mouse.GetPosition(AssociatedObject);
			RippleFinal.SetMousePosition(AssociatedObject, mousePos);
		}
	}
}
/*		private void UnregisterEventImpl(object obj, string eventName)
		{
			var type = obj.GetType();
			if (eventHandlerMethodInfo == null)
				return;
			var @event = type.GetEvent(eventName);
			@event.RemoveEventHandler(obj, Delegate.CreateDelegate(@event.EventHandlerType, this, eventHandlerMethodInfo));
			eventHandlerMethodInfo = null;
		}*/