using System.Windows.Controls;
using System.Windows.Input;
using Core.Controls;
using Core.Data.CachedObjects;
using Material.Extensions;
using UST_Routing.Accounts;
using UST_Routing.Data;
using UST_Routing.Data.Domain;

namespace UST_Routing.ViewModels
{
	public class RegisterViewModel : LinqEntityViewModel
	{
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

		private string firstName;
		public string FirstName
		{
			get { return firstName; }
			set
			{
				firstName = value;
				NotifyOfPropertyChange(() => FirstName);
			}
		}

		private string lastName;
		public string LastName
		{
			get { return lastName; }
			set
			{
				lastName = value;
				NotifyOfPropertyChange(() => LastName);
			}
		}

		private string emailAddress;
		public string EmailAddress
		{
			get { return emailAddress; }
			set
			{
				emailAddress = value;
				NotifyOfPropertyChange(() => EmailAddress);
			}
		}

		public ICommand SignUpCommand => new FlexCommand(o =>
		{
			var passwordBox = o.As<PasswordBox>();
			APL.I.AddUserAccount(new UserAccount(Username, EmailAddress, passwordBox.Password, AccountType.StandardUser,
				FirstName, LastName));
		});

	}
}
