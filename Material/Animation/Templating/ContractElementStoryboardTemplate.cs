﻿using System.Windows.Media.Animation;
using Core.Extensions;
using Material.Extensions;

namespace Material.Animation.Templating
{
	public class ContractElementStoryboardTemplate : StoryboardTemplate
	{
		private const string targetTransformGroup = "(UIElement.RenderTransform).(TransformGroup.Children)";
		private const string scaleTransformTarget = targetTransformGroup + "[0]";
		private const string scaleXTarget = scaleTransformTarget + ".(ScaleTransform.ScaleX)";
		private const string scaleYTarget = scaleTransformTarget + ".(ScaleTransform.ScaleY)";
		private const string translateTransformTarget = targetTransformGroup + "[1]";
		private const string translateYTarget = translateTransformTarget + ".(TranslateTransform.Y)";

		protected override Storyboard GenerateStoryboardTreeImpl()
		{
			return new ScopedStoryboard
			{
				Duration = 250.MillisecondsD(),
				Children = new TimelineCollection
				{
					new DoubleAnimation
					{
						To = 0.5,
						EasingFunction = new CubicEase
						{
							EasingMode = EasingMode.EaseIn
						}
					}.Set(TargetPropertyProperty, scaleXTarget),
					new DoubleAnimation
					{
						To = 0.5,
						EasingFunction = new CubicEase
						{
							EasingMode = EasingMode.EaseIn
						}
					}.Set(TargetPropertyProperty, scaleYTarget),
					new DoubleAnimation
					{
						To = 200,
						EasingFunction = new QuadraticEase
						{
							EasingMode = EasingMode.EaseIn
						}
					}.Set(TargetPropertyProperty, translateYTarget),
					new DoubleAnimation
					{
						To = 0,
						EasingFunction = new QuadraticEase
						{
							EasingMode = EasingMode.EaseIn
						}
					}.Set(TargetPropertyProperty, "Opacity"),
					new ObjectAnimationUsingKeyFrames
					{
						Duration = 200.MillisecondsD(),
						KeyFrames = new ObjectKeyFrameCollection
						{
							new DiscreteObjectKeyFrame(false, 0.MillisecondsK())
						}
					}.Set(TargetPropertyProperty, "IsHitTestVisible")
				}
			}.Set(TargetPropertyProperty, GetTargetName(this));
		}
	}
}
