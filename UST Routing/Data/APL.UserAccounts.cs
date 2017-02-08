using System.Linq;
using System.Security.Authentication;
using JetBrains.Annotations;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data
{
	public partial class APL
	{
		[NotNull]
		public UserAccount AddUserAccount([NotNull] UserAccount userAccount)
		{
			using (var context = ctx)
			{
				return AddUserAccountImpl(context, userAccount);
			}
		}
		[NotNull]
		protected UserAccount AddUserAccountImpl(
			[NotNull] USTDataContext context,
			[NotNull] UserAccount userAccount,
			bool submitChanges = true)
		{
			ThrowIfNull(context);
			ThrowIfNull(userAccount);

			context.UserAccounts.InsertOnSubmit(userAccount);
			if (submitChanges)
				context.SubmitChanges();

			return userAccount;
		}


		[CanBeNull]
		public UserAccount FetchUserAccount(int userAccountID)
		{
			using (var context = ctx)
			{
				return FetchUserAccountImpl(context, userAccountID);
			}
		}
		[CanBeNull]
		protected UserAccount FetchUserAccountImpl(
			[NotNull] USTDataContext context,
			int userAccountID)
		{
			ThrowIfNull(context);

			return context.UserAccounts.SingleOrDefault(t => t.UserAccountID == userAccountID);
		}


		[CanBeNull]
		public UserAccount FetchUserAccountFromUsername(string username)
		{
			using (var context = ctx)
			{
				return FetchUserFromUsernameAccountImpl(context, username);
			}
		}
		[CanBeNull]
		protected UserAccount FetchUserFromUsernameAccountImpl(
			[NotNull] USTDataContext context,
			string username)
		{
			ThrowIfNull(context);

			return context.UserAccounts.SingleOrDefault(t => t.Username == username);
		}


		public UserAccount[] GetAllUserAccounts()
		{
			using (var context = new USTDataContext())
			{
				return GetAllUserAccountsImpl(context).ToArray();
			}
		}
		protected IQueryable<UserAccount> GetAllUserAccountsImpl(
			[NotNull] USTDataContext context)
		{
			ThrowIfNull(context);

			return context.UserAccounts;
		}


		public UserAccount[] GetAllUserAccountsExcludingActive()
		{
			using (var context = new USTDataContext())
			{
				return GetAllUserAccountsExcludingActiveImpl(context).ToArray();
			}
		}
		protected IQueryable<UserAccount> GetAllUserAccountsExcludingActiveImpl(
			[NotNull] USTDataContext context)
		{
			ThrowIfNull(context);
			if(!I.IsAuthenticated)
				throw new AuthenticationException("There is no user currently authenticated.");

			return context.UserAccounts.Where(t => t.UserAccountID != I.CurrentUserAccount.UserAccountID);
		}


	}
}
 