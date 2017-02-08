using System;
using System.Windows;
using System.Windows.Media.Animation;
using Core.Extensions;
using Material.Extensions;

namespace Material.Animation
{
	//public class ContractElementStoryboard : Storyboard
	//{
	//	static ContractElementStoryboard()
	//	{
	//		TargetNameProperty.OverrideMetadata(typeof(ContractElementStoryboard),
	//			new FrameworkPropertyMetadata(onTargetNameChanged));
	//	}

	//	private static void onTargetNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	//	{
	//		o.As<ContractElementStoryboard>().generateInternalTree();
	//	}

	//	private void generateInternalTree()
	//	{
	//		var targetName = GetTargetName(this);
	//		if (targetName.IsNullOrEmpty())
	//		{
	//			Children = new TimelineCollection();
	//			return;
	//		}

	//		var targetTransformGroup = "(UIElement.RenderTransform).(TransformGroup.Children)";
	//		var scaleTransformTarget = targetTransformGroup + "[0]";
	//		var scaleXTarget = scaleTransformTarget + ".(ScaleTransform.ScaleX)";
	//		var scaleYTarget = scaleTransformTarget + ".(ScaleTransform.ScaleY)";
	//		var translateTransformTarget = targetTransformGroup + "[1]";
	//		var translateYTarget = translateTransformTarget + ".(TranslateTransform.Y)";

	//		//var parentStoryboard = new Storyboard();
	//		var storyboard2 = new ScopedStoryboard
	//		{
	//			Duration = 250.MillisecondsD()
	//		}.Set(TargetPropertyProperty, GetTargetName(this));

	//		//SetTargetName(this, targetName);
	//		storyboard2.Children = new TimelineCollection
	//		{
	//			new DoubleAnimation
	//			{
	//				To = 0.5,
	//				EasingFunction = new CubicEase
	//				{
	//					EasingMode = EasingMode.EaseIn
	//				}
	//			}.Set(TargetPropertyProperty, scaleXTarget),
	//			new DoubleAnimation
	//			{
	//				To = 0.5,
	//				EasingFunction = new CubicEase
	//				{
	//					EasingMode = EasingMode.EaseIn
	//				}
	//			}.Set(TargetPropertyProperty, scaleYTarget),
	//			new DoubleAnimation
	//			{
	//				To = 200,
	//				EasingFunction = new QuadraticEase
	//				{
	//					EasingMode = EasingMode.EaseIn
	//				}
	//			}.Set(TargetPropertyProperty, translateYTarget),
	//			new DoubleAnimation
	//			{
	//				To = 0,
	//				EasingFunction = new QuadraticEase
	//				{
	//					EasingMode = EasingMode.EaseIn
	//				}
	//			}.Set(TargetPropertyProperty, "Opacity"),
	//			new ObjectAnimationUsingKeyFrames
	//			{
	//				Duration = 200.MillisecondsD(),
	//				KeyFrames = new ObjectKeyFrameCollection
	//				{
	//					new DiscreteObjectKeyFrame(false, 0.MillisecondsK())
	//				}
	//			}.Set(TargetPropertyProperty, "IsHitTestVisible")
	//		};
	//		Children = new TimelineCollection
	//		{
	//			storyboard2
	//		};
	//	}
	//}
}
