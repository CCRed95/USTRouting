//using System.Windows;
//using System.Windows.Controls;
//using Core.Extensions;
//using Core.Helpers.ControlHelpers;
//using Core.Helpers.DependencyHelpers;
//using Material.Controls.Validation;

//namespace Material.Controls
//{
	//public class HintedTextBox : TextBox
	//{
	//	public static readonly DependencyProperty HintProperty = DP.Register(
	//		new Meta<HintedTextBox, string>());

	//	public static readonly DependencyProperty IconProperty = DP.Register(
	//		new Meta<HintedTextBox, Style>());

	//	public static readonly DependencyProperty ValidatorProperty = DP.Register(
	//		new Meta<HintedTextBox, StringValidator>(StringValidator.Empty));


	//	public string Hint
	//	{
	//		get { return (string)GetValue(HintProperty); }
	//		set { SetValue(HintProperty, value); }
	//	}
	//	public Style Icon
	//	{
	//		get { return (Style)GetValue(IconProperty); }
	//		set { SetValue(IconProperty, value); }
	//	}
	//	public StringValidator Validator
	//	{
	//		get { return (StringValidator)GetValue(ValidatorProperty); }
	//		set { SetValue(ValidatorProperty, value); }
	//	}

	//	static HintedTextBox()
	//	{
	//		Ctrl.OverrideDefaultStyleKey<HintedTextBox>();
	//	}
	//	public HintedTextBox()
	//	{
	//		IsKeyboardFocusWithinChanged += onKeyboardFocusedWithinChanged;
	//		TextChanged += onTextChanged;
	//		Loaded += OnLoaded;
	//	}

	//	private void onTextChanged(object s, TextChangedEventArgs e)
	//	{
	//		var validationResult = Validator.Validate(Text);
	//		this.GoToVisualState(validationResult ? "Valid" : "Invalid");
	//	}

	//	private void OnLoaded(object Sender, RoutedEventArgs Args)
	//	{
	//		updateState();
	//	}

	//	private void onKeyboardFocusedWithinChanged(object s, DependencyPropertyChangedEventArgs e)
	//	{
	//		updateState();
	//	}

	//	private void updateState()
	//	{
	//		if (IsKeyboardFocusWithin)
	//		{
	//			VisualStateManager.GoToState(this, "Small", true);
	//		}
	//		else
	//		{
	//			VisualStateManager.GoToState(this, Text.IsNullOrWhiteSpace() ?
	//				"Visible" : "Invisible", true);
	//		}
	//	}
//	}
