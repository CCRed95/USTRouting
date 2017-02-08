using System;
using System.Windows;
using System.Windows.Media;
using Core.Helpers.DependencyHelpers;
using Material.Extensions;
using Material.Static;

namespace Material.Media
{
	public class BlendedBrush : AnimatableAttachableBase
	{
		public static readonly DependencyProperty Layer1Property = DP.Register(
			new Meta<BlendedBrush, SolidColorBrush>(null, onLayerChanged));

		public static readonly DependencyProperty Layer2Property = DP.Register(
			new Meta<BlendedBrush, SolidColorBrush>(null, onLayerChanged));

		public static readonly DependencyProperty LightenPercentageProperty = DP.Register(
			new Meta<BlendedBrush, double>(0, onLightenPercentageChanged));


		public SolidColorBrush Layer1
		{
			get { return (SolidColorBrush)GetValue(Layer1Property); }
			set { SetValue(Layer1Property, value); }
		}
		public SolidColorBrush Layer2
		{
			get { return (SolidColorBrush)GetValue(Layer2Property); }
			set { SetValue(Layer2Property, value); }
		}
		public double LightenPercentage
		{
			get { return (double)GetValue(LightenPercentageProperty); }
			set { SetValue(LightenPercentageProperty, value); }
		}


		private static void onLightenPercentageChanged(BlendedBrush i, DPChangedEventArgs<double> e)
		{
			i.UpdateAttachedSolidColorBrush();
		}

		private static void onLayerChanged(BlendedBrush i, DPChangedEventArgs<SolidColorBrush> e)
		{
			i.UpdateAttachedSolidColorBrush();
		}

		protected override void OnAttached()
		{
			base.OnAttached();
			UpdateAttachedSolidColorBrush();
		}

		protected void UpdateAttachedSolidColorBrush()
		{
			try
			{
				if (Layer1 == null && Layer2 == null)
				{
					var associatedBrush = (SolidColorBrush)AssociatedObject;
					associatedBrush.Color = Palette.Pink.A400.Color;
					associatedBrush.Opacity = 1;
				}
				else if (Layer1 == null)
				{
					var associatedBrush = (SolidColorBrush)AssociatedObject;
					associatedBrush.Color = Layer2.Color.Lighten(LightenPercentage);
					associatedBrush.Opacity = 1;
				}
				else if (Layer2 == null)
				{
					var associatedBrush = (SolidColorBrush)AssociatedObject;
					associatedBrush.Color = Layer1.Color.Lighten(LightenPercentage);
					associatedBrush.Opacity = 1;
				}
				else
				{
					var associatedBrush = (SolidColorBrush)AssociatedObject;
					var calculatedColor = Layer1.Color.Blend(Layer2.Color, Layer2.Opacity).Lighten(LightenPercentage);
					associatedBrush.Color = calculatedColor;
					associatedBrush.Opacity = Layer1.Opacity;
				}
			}
			catch
			{
				var associatedBrush = (SolidColorBrush)AssociatedObject;
				associatedBrush.Color = Palette.Amber.A400.Color;
				associatedBrush.Opacity = 1;
			}

		}

		protected override Freezable CreateInstanceCore()
		{
			return new BlendedBrush();
		}
	}
}
