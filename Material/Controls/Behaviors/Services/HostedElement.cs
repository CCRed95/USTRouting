using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Material.Controls.Behaviors.Services
{
	public class HostedElement<TElement>
	{
		protected TElement hostedElement;
		public TElement Element => hostedElement;

		public void AttachElement([NotNull] TElement element)
		{
			//if(attachedElement != null)
			//	throw new Exception("ElementProxyServices cannot have more than one attached element.");
			if (hostedElement != null)
				Debug.WriteLine("already an attached element");
			hostedElement = element;

			OnElementAttached();
		}


		protected virtual void OnElementAttached()
		{
		}

	}
}
