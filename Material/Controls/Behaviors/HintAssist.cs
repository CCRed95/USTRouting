using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core.Helpers.DependencyHelpers;
using Material.Controls.Validation;
using Material.Extensions;

namespace Material.Controls.Behaviors
{
	public static class HintAssist
	{
		public static readonly DependencyProperty IsFloatingProperty = DependencyProperty.RegisterAttached(
				"IsFloating",
				typeof(bool),
				typeof(HintAssist),
				new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.Inherits));

		public static bool GetIsFloating(DependencyObject element)
		{
			return (bool)element.GetValue(IsFloatingProperty);
		}

		public static void SetIsFloating(DependencyObject element, bool value)
		{
			element.SetValue(IsFloatingProperty, value);
		}
		
		/// <summary>
		/// The hint property
		/// </summary>
		public static readonly DependencyProperty HintProperty = DependencyProperty.RegisterAttached(
				"Hint",
				typeof(object),
				typeof(HintAssist),
				new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.Inherits));

		/// <summary>
		/// Sets the hint.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="value">The value.</param>
		public static void SetHint(DependencyObject element, object value)
		{
			element.SetValue(HintProperty, value);
		}

		/// <summary>
		/// Gets the hint.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns>
		/// The <see cref="string" />.
		/// </returns>
		public static object GetHint(DependencyObject element)
		{
			return element.GetValue(HintProperty);
		}
		
		/// <summary>
		/// The hint opacity property
		/// </summary>
		public static readonly DependencyProperty HintOpacityProperty = DependencyProperty.RegisterAttached(
				"HintOpacity",
				typeof(double),
				typeof(HintAssist),
				new PropertyMetadata(.56));

		/// <summary>
		/// Gets the text box view margin.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns>
		/// The <see cref="Thickness" />.
		/// </returns>
		public static double GetHintOpacityProperty(DependencyObject element)
		{
			return (double)element.GetValue(HintOpacityProperty);
		}

		/// <summary>
		/// Sets the hint opacity.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="value">The value.</param>
		public static void SetHintOpacity(DependencyObject element, double value)
		{
			element.SetValue(HintOpacityProperty, value);
		}

		//public static readonly DependencyProperty IconProperty =
		//	DP.Attach<Style>(typeof(HintAssist), new FrameworkPropertyMetadata());

		//public static Style GetIcon(DependencyObject i) => i.Get<Style>(IconProperty);
		//public static void SetIcon(DependencyObject i, Style v) => i.Set(IconProperty, v);



		public static readonly DependencyProperty IconStyleProperty =
			DP.Attach<Style>(typeof(HintAssist), new FrameworkPropertyMetadata(onIconStyleChanged));

		public static Style GetIconStyle(DependencyObject i) => i.Get<Style>(IconStyleProperty);
		public static void SetIconStyle(DependencyObject i, Style v) => i.Set(IconStyleProperty, v);


		private static void onIconStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var style = e.NewValue.As<Style>();
			var geometry = style.Setters.Single().As<Setter>().Value;
			SetIconGeometry(o, geometry.As<Geometry>());
		}



		public static readonly DependencyProperty IconGeometryProperty =
			DP.Attach<Geometry>(typeof(HintAssist), new FrameworkPropertyMetadata());

		public static Geometry GetIconGeometry(DependencyObject i) => i.Get<Geometry>(IconGeometryProperty);
		public static void SetIconGeometry(DependencyObject i, Geometry v) => i.Set(IconGeometryProperty, v);


		public static readonly DependencyProperty VisualStateManagerServiceProperty =
			DP.Attach<HintVisualStateManagerService>(typeof(HintAssist), new FrameworkPropertyMetadata(onVisualStateManagerServiceChanged));

		public static HintVisualStateManagerService GetVisualStateManagerService(DependencyObject i) => i.Get<HintVisualStateManagerService>(VisualStateManagerServiceProperty);
		public static void SetVisualStateManagerService(DependencyObject i, HintVisualStateManagerService v) => i.Set(VisualStateManagerServiceProperty, v);


		private static void onVisualStateManagerServiceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var visualStateManagerService = e.NewValue.As<HintVisualStateManagerService>();
			var frameworkInputElement = o as IFrameworkInputElement;
			if (frameworkInputElement == null)
				throw new ArgumentException(
					$"The service \'HintAssist.VisualStateManagerService\' can only be used " +
					$"with elements that implement the \'IFrameworkInputElement\' interface.");

			visualStateManagerService.AttachElement(frameworkInputElement);
		}


		public static readonly DependencyProperty ValidatorProperty =
			DP.Attach<StringValidator>(typeof(HintAssist), new FrameworkPropertyMetadata(onValidatorChanged));

		private static void onValidatorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var validator = e.NewValue.As<StringValidator>();
			o.As<IFrameworkInputElement>().TextInput += (s, x) =>
			{
				validator.Validate(x.Text);
			};
		}

		public static StringValidator GetValidator(DependencyObject i) => i.Get<StringValidator>(ValidatorProperty);
		public static void SetValidator(DependencyObject i, StringValidator v) => i.Set(ValidatorProperty, v);


	}
}
