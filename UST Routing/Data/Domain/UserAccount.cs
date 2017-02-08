using System;
using Core.Data.CachedObjects;
using UST_Routing.Accounts;

namespace UST_Routing.Data.Domain
{
	public partial class UserAccount : LinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();

		public UserAccount(
			string username,
			string emailAddress,
			string password,
			AccountType accountType,
			string firstName,
			string lastName,
			string jobTitle = null,
			string imagePath = null)
		{
			Username = username;
			EmailAddress = emailAddress;
			Password = password;
			AccountType = (int)accountType;
			FirstName = firstName;
			LastName = lastName;
			JobTitle = jobTitle;
			ImagePath = imagePath;
			Created = DateTime.UtcNow;
		}
	}
}
