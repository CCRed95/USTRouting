using System;
using System.ComponentModel;
using Core.Data;
using Core.Extensions;
using Core.Helpers.CLREventHelpers;
using UST_Routing.Accounts;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data
{
	public partial class APL
	{
		#region Properties
		private UserAccount _adminUserAccount => new Ref<string, UserAccount>("admin", I.FetchUserAccountFromUsername);

		private UserAccount _currentUserAccount;
		public UserAccount CurrentUserAccount
		{
			get
			{
				if (IsInDesignMode)
					return _adminUserAccount;

				return _currentUserAccount;
			}
			set
			{
				_currentUserAccount = value;
				OnPropertyChanged();
			}
		}


		public bool IsAuthenticated => CurrentUserAccount != null;


		#endregion
		public void Authenticate(string username, string password)
		{
			UserAccount _userAccount;
			var authResult = TryAuthenticate(username, password, out _userAccount);
			switch (authResult)
			{
				case AuthenticationResult.Success:
					{
						connectToAccount(_userAccount);
						AuthenticationSuccess.Raise(CurrentUserAccount);
						break;
					}
				default:
					{
						AuthenticationFailed.Raise(authResult);
						break;
					}
			}
		}
		protected static AuthenticationResult TryAuthenticate(string username, string password, out UserAccount userAccount)
		{
			try
			{
				using (var context = new USTDataContext())
				{
					var currentUserAccount = I.FetchUserFromUsernameAccountImpl(context, username);

					if (currentUserAccount == null)
					{
						userAccount = default(UserAccount);
						return AuthenticationResult.UsernameError;
					}

					if (currentUserAccount.Password == password)
					{
						I.CurrentUserAccount = currentUserAccount;
						userAccount = currentUserAccount;
						return AuthenticationResult.Success;
					}

					userAccount = default(UserAccount);
					return AuthenticationResult.PasswordError;
				}
			}
			catch (Exception ex)
			{
				userAccount = default(UserAccount);
				return AuthenticationResult.UnknownError;
			}
		}

		protected void connectToAccount(UserAccount userAccount)
		{
			CurrentUserAccount = userAccount;
			CurrentUserAccount.PropertyChanged += onAccountPropertyChanged;
		}

		private void onAccountPropertyChanged(object s, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "PropertyToWatchFor":
					break;
			}
		}


		#region Events
		public event ParameterizedEventHandler<UserAccount> AuthenticationSuccess;

		public event ParameterizedEventHandler<AuthenticationResult> AuthenticationFailed;
		#endregion

	}
}
