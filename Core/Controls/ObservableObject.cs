using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using JetBrains.Annotations;

namespace Core.Controls
{
	public class ObservableObject : INotifyPropertyChanged
	{
		private DependencyObject DesignerModeDO => new DependencyObject();
		public bool IsInDesignMode => DesignerProperties.GetIsInDesignMode(DesignerModeDO);

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
		}
		[ContractAnnotation("object:null => halt;")]
		protected void ThrowIfNull(object @object, [CallerMemberName] string parameterName = null)
		{
			if (@object == null)
				throw new ArgumentNullException(nameof(parameterName));

		}

	}
}
