using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Material.Animation
{
	public class ScopedStoryboard : Storyboard
	{
		public ScopedStoryboard()
		{
			Children.Changed += onChildrenChanged;
		}

		private void onChildrenChanged(object s, EventArgs e)
		{
			var groupTargetName = GetTargetName(this);
			if (groupTargetName != null)
			{
				foreach (var animation in Children)
				{
					var targetName = GetTargetName(animation);
					if (targetName == null)
					{
						SetTargetName(animation, groupTargetName);
					}
				}
			}
			if (Duration != Duration.Automatic)
			{
				foreach (var animation in Children)
				{
					if (animation.Duration == Duration.Automatic)
					{
						animation.Duration = Duration;
					}
				}
			}
		}
	}
}
