using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Material.Controls.Behaviors
{
	public abstract class AbstractElementProxyService<TElement>
	{
		protected TElement attachedElement;
		public TElement AttachedElement => attachedElement;

		public void AttachElement([NotNull] TElement element)
		{
			//if(attachedElement != null)
			//	throw new Exception("ElementProxyServices cannot have more than one attached element.");
			if(attachedElement != null)
				Debug.WriteLine("already an attached element");
			attachedElement = element;

			OnElementAttached();
		}


		protected virtual void OnElementAttached()
		{
		}

	}
}
