using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using Core.Helpers.DependencyHelpers;
using Core.Markup;
using Core.Markup.Converters;
using Material.Converters;

namespace Material.Design.Text
{
	//TODO could this recievemarkupextension/typeconverter to extract BindingRelativeSource by default on bind?
	//TODO something is not right with how Padding is handled. Should all bound FE's padding be set to 0?
	//TODO Horiz/Vert Content Alignment control capability! How to handle this with non-control frameworkelements like TextBlock?
	public partial class TextualStyle
	{
		public static readonly DependencyProperty BindingRelativeSourceProperty =
			DP.Attach<RelativeSource>(typeof(TextualStyle), new FrameworkPropertyMetadata(new RelativeSource(RelativeSourceMode.TemplatedParent), onDependentPropertyChanged));

		//TODO change name, just source not relativesource?
		public static readonly DependencyProperty ForegroundMaterialSetRelativeSourceProperty =
			DP.Attach<DependencyObject>(typeof(TextualStyle), new FrameworkPropertyMetadata(null, onDependentPropertyChanged));

		public static readonly DependencyProperty BindStyleProperty =
			DP.Attach<TextualStyle>(typeof(TextualStyle), new FrameworkPropertyMetadata(new TextualStyle(), onDependentPropertyChanged));

		public static readonly DependencyProperty IsHighContrastBindingProperty =
			DP.Attach<bool>(typeof(TextualStyle), new FrameworkPropertyMetadata(false, onDependentPropertyChanged));

		public static readonly DependencyProperty HighContrastBindingContextProperty =
			DP.Attach<SolidColorBrush>(typeof(TextualStyle), new FrameworkPropertyMetadata(null, onDependentPropertyChanged));

		//public static readonly DependencyProperty HighContrastBindingThresholdProperty =
		//	DP.Attach<double>(typeof(TextualStyle), new FrameworkPropertyMetadata(.3));

		

		public static RelativeSource GetBindingRelativeSource(DependencyObject i) => i.Get<RelativeSource>(BindingRelativeSourceProperty);
		public static void SetBindingRelativeSource(DependencyObject i, RelativeSource v) => i.Set(BindingRelativeSourceProperty, v);

		public static DependencyObject GetForegroundMaterialSetRelativeSource(DependencyObject i) => i.Get<DependencyObject>(ForegroundMaterialSetRelativeSourceProperty);
		public static void SetForegroundMaterialSetRelativeSource(DependencyObject i, DependencyObject v) => i.Set(ForegroundMaterialSetRelativeSourceProperty, v);

		public static TextualStyle GetBindStyle(DependencyObject i) => i.Get<TextualStyle>(BindStyleProperty);
		public static void SetBindStyle(DependencyObject i, TextualStyle v) => i.Set(BindStyleProperty, v);

		public static bool GetIsHighContrastBinding(DependencyObject i) => i.Get<bool>(IsHighContrastBindingProperty);
		public static void SetIsHighContrastBinding(DependencyObject i, bool v) => i.Set(IsHighContrastBindingProperty, v);

		public static SolidColorBrush GetHighContrastBindingContext(DependencyObject i) => i.Get<SolidColorBrush>(HighContrastBindingContextProperty);
		public static void SetHighContrastBindingContext(DependencyObject i, SolidColorBrush v) => i.Set(HighContrastBindingContextProperty, v);

		//public static double GetHighContrastBindingThreshold(DependencyObject i) => i.Get<double>(HighContrastBindingThresholdProperty);
		//public static void SetHighContrastBindingThreshold(DependencyObject i, double v) => i.Set(HighContrastBindingThresholdProperty, v);




		private static void onDependentPropertyChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
		{
			var frameworkElement = @this as FrameworkElement;
			if (frameworkElement == null)
				throw new InvalidCastException("BindingRelativeSource target object must be a FrameworkElement.");

			//var relativeSource = e.NewValue as RelativeSource;
			//if (relativeSource == null)
			//	throw new InvalidCastException("BindingRelativeSource value must be a RelativeSource.");

			var textualStyle = GetBindStyle(@this);
			var relativeSource = GetBindingRelativeSource(@this);
			var foregroundMaterialSetRelativeSource = GetForegroundMaterialSetRelativeSource(@this);
			var isHighContrastBinding = GetIsHighContrastBinding(@this);
			var highContrastBindingContext = GetHighContrastBindingContext(@this);
			//var highContrastBindingThreshold = GetHighContrastBindingThreshold(@this);

			bindTextualStyleImpl(frameworkElement, textualStyle, relativeSource, foregroundMaterialSetRelativeSource,
				isHighContrastBinding, highContrastBindingContext); //, highContrastBindingThreshold);
		}
		//private static void onForegroundMaterialSetRelativeSourceChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
		//{
		//	var control = @this as FrameworkElement;
		//	if (control == null)
		//		throw new InvalidCastException("ForegroundMaterialSetRelativeSource target object must be a FrameworkElement.");

		//	var relativeSource = e.NewValue as DependencyObject;
		//	if (relativeSource == null)
		//		throw new InvalidCastException("ForegroundMaterialSetRelativeSource value must be a DependencyObject.");

		//	var bindingRelativeSource = GetBindingRelativeSource(@this);
		//	var textualStyle = GetBindStyle(@this);
		//	var isHighContrastBinding = GetIsHighContrastBinding(@this);
		//	var highContrastBindingContext = GetHighContrastBindingContext(@this);

		//	bindTextualStyleImpl(control, textualStyle, relativeSource, foregroundMaterialSetRelativeSource, isHighContrastBinding, highContrastBindingContext);
		//}
		//private static void onBindStyleChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
		//{
		//	var control = @this as FrameworkElement;
		//	if (control == null)
		//		throw new InvalidCastException("BindStyle target object must be a FrameworkElement.");

		//	var textualStyle = e.NewValue as TextualStyle;
		//	if (textualStyle == null)
		//		throw new InvalidCastException("BindStyle value must be a TextualStyle.");

		//	var relativeSource = GetBindingRelativeSource(@this);
		//	var foregroundMaterialSetRelativeSource = GetForegroundMaterialSetRelativeSource(@this);
		//	var isHighContrastBinding = GetIsHighContrastBinding(@this);
		//	var highContrastBindingContext = GetHighContrastBindingContext(@this);

		//	bindTextualStyleImpl(control, textualStyle, relativeSource, foregroundMaterialSetRelativeSource, isHighContrastBinding, highContrastBindingContext);
		//}

		//private static void onIsHighContrastBindingChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
		//{
		//	var control = @this as FrameworkElement;
		//	if (control == null)
		//		throw new InvalidCastException("BindStyle target object must be a FrameworkElement.");

		//	var textualStyle = e.NewValue as TextualStyle;
		//	if (textualStyle == null)
		//		throw new InvalidCastException("BindStyle value must be a TextualStyle.");

		//	var relativeSource = GetBindingRelativeSource(@this);
		//	var foregroundMaterialSetRelativeSource = GetForegroundMaterialSetRelativeSource(@this);
		//	var isHighContrastBinding = GetIsHighContrastBinding(@this);
		//	var highContrastBindingContext = GetHighContrastBindingContext(@this);

		//	bindTextualStyleImpl(control, textualStyle, relativeSource, foregroundMaterialSetRelativeSource, isHighContrastBinding, highContrastBindingContext);
		//}

		//private static void onHighContrastBindingContextChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
		//{
		//	var control = @this as FrameworkElement;
		//	if (control == null)
		//		throw new InvalidCastException("BindStyle target object must be a FrameworkElement.");

		//	var textualStyle = e.NewValue as TextualStyle;
		//	if (textualStyle == null)
		//		throw new InvalidCastException("BindStyle value must be a TextualStyle.");

		//	var relativeSource = GetBindingRelativeSource(@this);
		//	var foregroundMaterialSetRelativeSource = GetForegroundMaterialSetRelativeSource(@this);
		//	var isHighContrastBinding = GetIsHighContrastBinding(@this);
		//	var highContrastBindingContext = GetHighContrastBindingContext(@this);

		//	bindTextualStyleImpl(control, textualStyle, relativeSource, foregroundMaterialSetRelativeSource, isHighContrastBinding, highContrastBindingContext);
		//}


		private static void bindTextualStyleImpl(
			FrameworkElement @this,
			TextualStyle textualStyle,
			RelativeSource relativeSource,
			DependencyObject foregroundMaterialSetRelativeSource,
			bool isHighContrastBinding,
			SolidColorBrush highContrastBindingContext)
			//double highContrastBindingThreshold)
		{
			BindingOperations.SetBinding(@this, TextElement.FontFamilyProperty, new Binding(FontFamilyProperty.Name) { Source = textualStyle });
			BindingOperations.SetBinding(@this, TextElement.FontStyleProperty, new Binding(FontStyleProperty.Name) { Source = textualStyle });
			BindingOperations.SetBinding(@this, TextElement.FontWeightProperty, new Binding(FontWeightProperty.Name) { Source = textualStyle });
			BindingOperations.SetBinding(@this, TextElement.FontStretchProperty, new Binding(FontStretchProperty.Name) { Source = textualStyle });
			//BindingOperations.SetBinding(@this, Control.PaddingProperty, new Binding(PaddingProperty.Name) { Source = textualStyle });
			BindingOperations.SetBinding(@this, TextElement.FontSizeProperty, new MultiBinding
			{
				Converter = new MultiplyMultiConverter(),
				Bindings =
					{
						new Binding
						{
							RelativeSource = relativeSource,
							Path = new PropertyPath("FontSize")
						},
						new Binding
						{
							Source = textualStyle,
							Path = new PropertyPath("RelativeFontSize")
						},
					}
			});
			if (foregroundMaterialSetRelativeSource == null)
			{
				if (isHighContrastBinding)
				{
					BindingOperations.SetBinding(@this, TextElement.ForegroundProperty,
						new MultiBinding
						{
							Converter = MarkupSingleton.GetInstance<HighContrastDescriptorToBrushConverter>(),
							Bindings =
							{
								new Binding
								{
									RelativeSource = relativeSource,
									Path = new PropertyPath("FallbackMaterialSet")
								},
								new Binding
								{
									Source = textualStyle,
									Path = new PropertyPath("ForegroundDescriptor")
								},
								new Binding
								{
									RelativeSource = relativeSource,
									Path = new PropertyPath("IsHighContrastOverlayedTextEnabled")
								},
								new Binding
								{
									Source = highContrastBindingContext
								},
								new Binding
								{
									RelativeSource = relativeSource,
									Path = new PropertyPath("HighContrastBindingThreshold")
								}
							}
						});
				}
				else
				{
					BindingOperations.SetBinding(@this, TextElement.ForegroundProperty,
						new MultiBinding
						{
							Converter = new DescriptorToBrushConverter(),
							Bindings =
							{
								new Binding
								{
									RelativeSource = relativeSource,
									Path = new PropertyPath("FallbackMaterialSet")
								},
								new Binding
								{
									Source = textualStyle,
									Path = new PropertyPath("ForegroundDescriptor")
								}
							}
						});
				}
			}
			else
			{
				if (isHighContrastBinding)
				{
					BindingOperations.SetBinding(@this, TextElement.ForegroundProperty,
						new MultiBinding
						{
							Converter = MarkupSingleton.GetInstance<HighContrastDescriptorToBrushConverter>(),
							Bindings =
							{
								new Binding
								{
									Source = foregroundMaterialSetRelativeSource
								},
								new Binding
								{
									Source = textualStyle,
									Path = new PropertyPath("ForegroundDescriptor")
								},
								new Binding
								{
									RelativeSource = relativeSource,
									Path = new PropertyPath("IsHighContrastOverlayedTextEnabled")
								},
								new Binding
								{
									Source = highContrastBindingContext
								},
								new Binding
								{
									RelativeSource = relativeSource,
									Path = new PropertyPath("HighContrastBindingThreshold")
								}
							}
						});
				}
				else
				{
					BindingOperations.SetBinding(@this, TextElement.ForegroundProperty,
						new MultiBinding
						{
							Converter = new DescriptorToBrushConverter(), //TODO use getinstance<> for all these, stop creating instances
							Bindings =
							{
								new Binding
								{
									Source = foregroundMaterialSetRelativeSource
								},
								new Binding
								{
									Source = textualStyle,
									Path = new PropertyPath("ForegroundDescriptor")
								}
							}
						});
				}
			}

			//@this.RenderTransformOrigin = new Point(.5, .5);
			double angle;
			switch (textualStyle.TextRotation)
			{
				case TextRotation.None:
					angle = 0;
					break;
				case TextRotation.Left:
					angle = -90;
					break;
				case TextRotation.Right:
					angle = 90;
					break;
				default:
					throw new InvalidEnumArgumentException(nameof(textualStyle.TextRotation), (int)textualStyle.TextRotation, typeof(TextRotation));
			}
			@this.LayoutTransform = new RotateTransform(angle, .5, .5);
		}



	}
}

//BindingOperations.SetBinding(@this.RenderTransform, RotateTransform.AngleProperty,
//	new Binding(TextRotationProperty.Name)
//	{
//		Converter = new TextRotationToAngleConverter(),
//		Source = textualStyle
//	});

//var border = new Border();
//@this.Bind(TextElement.FontFamilyProperty).To(FontFamilyProperty, textualStyle);
//@this.Bind(TextElement.FontStyleProperty).To("FontStyle", Find.AncestorAt<AbstractMVVMFlexChart>());
//@this.Bind(o => o.FontFamily).To2(border, o => o.Background.Opacity);
