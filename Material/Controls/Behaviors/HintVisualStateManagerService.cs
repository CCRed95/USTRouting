using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using Core.Extensions;
using Material.Controls.Adapters;
using Material.Controls.Validation;
using Material.Extensions;

namespace Material.Controls.Behaviors
{
	public static class HintVisualStates
	{
		private const string prefix = "Hint";

		public const string Visible = prefix + nameof(Visible);
		public const string Small = prefix + nameof(Small);
		public const string Invisible = prefix + nameof(Invisible);
	}

	public class HintVisualStateManagerService : AbstractElementProxyService<IFrameworkInputElement>
	{
		private TextFieldInputDataAdapter _inputDataAdapter;

		protected override void OnElementAttached()
		{
			_inputDataAdapter = new TextFieldInputDataAdapter(AttachedElement);

			attachedElement.As<FrameworkElement>().Loaded += OnLoaded;
			attachedElement.GotKeyboardFocus += OnGotKeyboardFocus;
			attachedElement.LostKeyboardFocus += OnLostKeyboardFocus;
			attachedElement.PreviewTextInput += OnPreviewTextInput;
		//	attachedElement.TextInput += OnTextInput;
		}

		private void OnLoaded(object s, RoutedEventArgs e)
		{
			var inputElement = e.Source.As<IFrameworkInputElement>();
			if (inputElement.IsKeyboardFocused)
			{
				e.Source.As<FrameworkElement>().GoToVisualState(HintVisualStates.Small);
			}
			else
			{
				OnLossOfFocus(s, e);
			}
		}

		private void OnGotKeyboardFocus(object s, KeyboardFocusChangedEventArgs e)
		{
			e.Source.As<FrameworkElement>().GoToVisualState(HintVisualStates.Small);
		}

		private void OnLostKeyboardFocus(object s, KeyboardFocusChangedEventArgs e)
		{
			OnLossOfFocus(s, e);
		}

		private void OnLossOfFocus(object s, RoutedEventArgs e)
		{
			var frameworkElement = e.Source.As<FrameworkElement>();
			frameworkElement.GoToVisualState(_inputDataAdapter.Text.IsNullOrEmpty() ? "HintVisible" : "Small");
			EvaluateValidationState(frameworkElement);
		}

		private void OnPreviewTextInput(object s, TextCompositionEventArgs e)
		{
		}

		public void EvaluateValidationState(FrameworkElement fe)
		{
			string targetState;
			var validator = HintAssist.GetValidator(fe);
			if (validator == null)
			{
				targetState = "NoValidation";
			}
			else
			{
				if (_inputDataAdapter == null)
					throw new DataException("The input data adapter has not been initialized.");
				var effectiveText = _inputDataAdapter.Text;
				var validationResult = validator.Validate(effectiveText);
				targetState = validationResult ? "ValidationPassed" : "ValidationFailed";
			}
			fe.GoToVisualState(targetState);
		}
	}

}


	//public class HintedPasswordBoxedVisualStateManagerService : AbstractElementProxyService<PasswordBox>
	//{
	//	protected override void OnElementAttached()
	//	{
	//		attachedElement.Loaded += OnLoaded;
	//		attachedElement.GotKeyboardFocus += OnGotKeyboardFocus;
	//		attachedElement.LostKeyboardFocus += OnLostKeyboardFocus;
	//		attachedElement.PreviewTextInput += OnPreviewTextInput;
	//		attachedElement.TextInput += OnTextInput;
	//	}

	//	private void OnLoaded(object s, RoutedEventArgs e)
	//	{
	//		var textBox = e.Source.As<TextBox>();
	//		if (textBox.IsKeyboardFocused)
	//		{
	//			e.Source.As<FrameworkElement>().GoToVisualState(HintVisualStates.Small);
	//		}
	//		else
	//		{
	//			textBox.GoToVisualState(textBox.Text.IsNullOrEmpty() ?
	//				HintVisualStates.Visible : HintVisualStates.Small);
	//		}
	//	}

	//	private void OnGotKeyboardFocus(object s, KeyboardFocusChangedEventArgs e)
	//	{
	//		e.Source.As<FrameworkElement>().GoToVisualState(HintVisualStates.Small);
	//	}

	//	private void OnLostKeyboardFocus(object s, KeyboardFocusChangedEventArgs e)
	//	{
	//		var textBox = e.Source.As<TextBox>();
	//		textBox.GoToVisualState(textBox.Text.IsNullOrEmpty() ?
	//			HintVisualStates.Visible : HintVisualStates.Small);
	//	}


	//	private void OnTextInput(object s, TextCompositionEventArgs e)
	//	{
	//	}

	//	private void OnPreviewTextInput(object s, TextCompositionEventArgs e)
	//	{
	//	}

	//}
