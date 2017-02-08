using System.Windows.Controls;
using System.Windows.Input;
using Core.Controls;
using Core.Data.CachedObjects;
using UST_Routing.Accounts;
using UST_Routing.Data;
using UST_Routing.Data.Domain;

namespace UST_Routing.ViewModels
{
	public class LoginViewModel : LinqEntityViewModel
	{
		public enum LoginViewStates
		{
			NormalState,
			ValidState,
			InvalidState
		}

		private LoginViewStates visualState = LoginViewStates.NormalState;
		public LoginViewStates VisualState
		{
			get { return visualState; }
			set
			{
				visualState = value;
				NotifyOfPropertyChange(() => VisualState);
			}
		}

		private string username;
		public string Username
		{
			get { return username; }
			set
			{
				username = value;
				NotifyOfPropertyChange(() => Username);
			}
		}

		public ICommand LoginCommand => new FlexCommand(
			o =>
			{
				var passwordBox = o as PasswordBox;
				if (passwordBox == null)
					return;
				var password = passwordBox.Password;
				APL.I.Authenticate(Username, password);
			},
			o =>
			{
				var passwordBox = o as PasswordBox;
				return !string.IsNullOrEmpty(passwordBox?.Password) &&
					!string.IsNullOrEmpty(Username);
			});


		public ICommand SwitchToRegisterViewCommand => new FlexCommand(
			o =>
			{
				_parentViewModel.AppModePage = AppRootViewModel.AppModePages.RegisterViewPage;
			});




		protected AppRootViewModel _parentViewModel;
		public LoginViewModel(AppRootViewModel parentViewModel)
		{
			_parentViewModel = parentViewModel;

			Username = LocalSettings.I.LastUsername;

			APL.I.AuthenticationFailed += onAuthenticationFailed;
			APL.I.AuthenticationSuccess += onAuthenticationSuccess;
		}

		private void onAuthenticationSuccess(UserAccount account)
		{
			LocalSettings.I.LastUsername = account.Username;
			VisualState = LoginViewStates.ValidState;
			_parentViewModel.LoginSuccessCallback();
		}

		private void onAuthenticationFailed(AuthenticationResult P1)
		{
			VisualState = LoginViewStates.InvalidState;
		}
	}
}
