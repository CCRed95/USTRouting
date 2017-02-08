using System;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace Material.Media
{
	//TODO why is this here...
	public abstract class AnimatableAttachableBase : Animatable, IAttachedObject
	{
		public DependencyObject AssociatedObject { get; protected set; }

		DependencyObject IAttachedObject.AssociatedObject => AssociatedObject;

		public event EventHandler AssociatedObjectChanged;
		
		public void Attach(DependencyObject dependencyObject)
		{
			if (dependencyObject == AssociatedObject)
				return;
			if (AssociatedObject != null)
				throw new InvalidOperationException("AttachableBase cannot host objects multiple times.")
				{
					Data = {
						["FailedObjectAssociation"] = dependencyObject.ToString(),
						["ExistingAssociatedObject"] = AssociatedObject.ToString() 
					}
				};
			AssociatedObject = dependencyObject;
			AssociatedObjectChanged?.Invoke(this, new EventArgs());
			OnAttached();
		}

		public void Detach()
		{
			OnDetaching();
			AssociatedObject = null;
		}
		
		protected virtual void OnAttached() { }
		
		protected virtual void OnDetaching() { }
	}
}
