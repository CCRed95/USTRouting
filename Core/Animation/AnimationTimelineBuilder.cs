using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Core.Helpers;
using Core.Parsers;

namespace Core.Animation
{
	internal class AnimationTimelineBuilder<T> where T : AnimationTimeline, new()
	{
		public T CompositeAnimation { get; protected set; } = new T();

		public void SetTargetName(IdentiferToken targetName)
		{
			Storyboard.SetTargetName(CompositeAnimation, targetName.Text);
		}

		public void SetTargetProperty(IdentiferToken targetProperty)
		{
			var ppc = new PropertyPathConverter();
			var propertyPath = ppc.ConvertFrom(targetProperty.Text);
			var pp = propertyPath as PropertyPath;
			if (pp == null)
				throw new FormatException($"TargetProperty path cannot be resolved from \"{targetProperty.Text}\".");
			Storyboard.SetTargetProperty(CompositeAnimation, (PropertyPath)propertyPath);
		}

		public void SetBeginTime(TimeSpanLiteralToken beginTime)
		{
			var timeSpan = beginTime.ToTimeSpan();
			CompositeAnimation.BeginTime = timeSpan;
		}

		public void SetDuration(TimeSpanLiteralToken duration)
		{
			var timeSpan = duration.ToTimeSpan();
			var value = new Duration(timeSpan);
			CompositeAnimation.Duration = value;
		}

		public void SetProgressionBlock(ProgressionBlockSyntacticUnit progressionBlock)
		{
			var reflectedFromProperty = ReflectionHelper.GetDependencyProperty("From", typeof(T), true);
			var reflectedByProperty = ReflectionHelper.GetDependencyProperty("By", typeof(T), true);
			var reflectedToProperty = ReflectionHelper.GetDependencyProperty("To", typeof(T), true);

			setProgressionBlockSegment(reflectedFromProperty, progressionBlock.From);
			setProgressionBlockSegment(reflectedByProperty, progressionBlock.By);
			setProgressionBlockSegment(reflectedToProperty, progressionBlock.To);
		}

		private void setProgressionBlockSegment(DependencyProperty property, UnknownLiteralToken token)
		{
			if (token?.Text == null) return;
			var converter = TypeDescriptor.GetConverter(property.PropertyType);
			var value = converter.ConvertFromInvariantString(token.Text);
			CompositeAnimation.SetValue(property, value);
		}

		public void SetEasing(IdentiferToken easingMode, IdentiferToken easingFunctionType, NumberLiteralToken param1 = null, NumberLiteralToken param2 = null)
		{
			var c1 = TypeDescriptor.GetConverter(typeof(EasingMode));
			var easingModeValue = (EasingMode)c1.ConvertFromInvariantString(easingMode.Text);

			var converter = TypeDescriptor.GetConverter(typeof(EasingType));

			var param1val = (param1 == null) ? (double?)null : Convert.ToDouble(param1.Text);
			var param2val = (param2 == null) ? (int?)null : Convert.ToInt32(param2.Text);

			var easingFunctionTypeValue = (EasingType)converter.ConvertFromInvariantString(easingFunctionType.Text);

			var easingFunctionValue = createEasingFunction(easingFunctionTypeValue, easingModeValue, param1val, param2val);
			var easingFunctionProperty = ReflectionHelper.GetDependencyProperty("EasingFunction", typeof(T), true);


			

			CompositeAnimation.SetValue(easingFunctionProperty, easingFunctionValue);
		}

		private EasingFunctionBase createEasingFunction(EasingType easingType, EasingMode easingMode, double? param1 = null, int? param2 = null)
		{
			EasingFunctionBase easingFunctionBase = null;
			switch (easingType)
			{
				case EasingType.Sine:
					easingFunctionBase = new SineEase();
					break;
				case EasingType.Cubic:
					easingFunctionBase = new CubicEase();
					break;
				case EasingType.Quint:
					easingFunctionBase = new QuinticEase();
					break;
				case EasingType.Circ:
					easingFunctionBase = new CircleEase();
					break;
				case EasingType.Quad:
					easingFunctionBase = new QuadraticEase();
					break;
				case EasingType.Quart:
					easingFunctionBase = new QuarticEase();
					break;
				case EasingType.Elastic:
					easingFunctionBase = new ElasticEase
					{
						Springiness = param1.GetValueOrDefault(3.0),
						Oscillations = param2.GetValueOrDefault(3)
					};
					break;
				case EasingType.Expo:
					easingFunctionBase = new ExponentialEase
					{
						Exponent = param1.GetValueOrDefault(2.0)
					};
					break;
				case EasingType.Back:
					easingFunctionBase = new BackEase
					{
						Amplitude = param1.GetValueOrDefault(1.0)
					};
					break;
				case EasingType.Bounce:
					easingFunctionBase = new BounceEase
					{
						Bounciness = param1.GetValueOrDefault(2.0),
						Bounces = param2.GetValueOrDefault(3)
					};
					break;
			}
			if (easingFunctionBase != null) easingFunctionBase.EasingMode = easingMode;
			return easingFunctionBase;
		}

	}
}
