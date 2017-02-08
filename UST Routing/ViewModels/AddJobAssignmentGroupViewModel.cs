using System.Collections.Generic;
using Core.Data.CachedCollections;
using Core.Data.CachedCollections.Sorting;
using Core.Data.CachedObjects;
using UST_Routing.Data;
using UST_Routing.Data.Domain;

namespace UST_Routing.ViewModels
{
	public class AddJobAssignmentGroupViewModel : LinqEntityViewModel
	{
		public enum AddJobAssignmentGroupStates
		{
			AssociateUserState,
			AddJobAssignmentState
		}

		private AddJobAssignmentGroupStates addJobAssignmentGroupState = AddJobAssignmentGroupStates.AssociateUserState;
		public AddJobAssignmentGroupStates AddJobAssignmentGroupState
		{
			get { return addJobAssignmentGroupState; }
			set
			{
				addJobAssignmentGroupState = value;
				NotifyOfPropertyChange(() => AddJobAssignmentGroupState);
			}
		}

		

		public static LinqProperty<AddJobAssignmentGroupViewModel, CachedCollection<UserAccount>> AccountsProperty =
			LinqPropertyBase.Register<AddJobAssignmentGroupViewModel, CachedCollection<UserAccount>>(AccountsEvaluator);

		public CachedCollection<UserAccount> Accounts => AccountsProperty.GetValue(this);
		

		private static CachedCollection<UserAccount> AccountsEvaluator(AddJobAssignmentGroupViewModel i)
		{
			var orderByInsertionStrategy = new OrderByInsertionStrategy<UserAccount, int>(
				t => t.UserAccountID, null, OrderByDirection.Ascending);

			var userList = APL.I.GetAllUserAccounts();

			return new CachedCollection<UserAccount>(userList, orderByInsertionStrategy);
		}

		private UserAccount selectedAccount;
		public UserAccount SelectedAccount
		{
			get { return selectedAccount; }
			set
			{
				selectedAccount = value;
				NotifyOfPropertyChange(() => SelectedAccount);
				
			}
		}

		public static LinqProperty<AddJobAssignmentGroupViewModel, CachedCollection<JobAssignmentGroup>> JobAssignmentGroupsProperty =
			LinqPropertyBase.Register<AddJobAssignmentGroupViewModel, CachedCollection<JobAssignmentGroup>>(JobAssignmentGroupsEvaluator);

		public CachedCollection<JobAssignmentGroup> JobAssignmentGroups => JobAssignmentGroupsProperty.GetValue(this);

		private static CachedCollection<JobAssignmentGroup> JobAssignmentGroupsEvaluator(AddJobAssignmentGroupViewModel i)
		{
			var orderByInsertionStrategy = new OrderByInsertionStrategy<JobAssignmentGroup, int>(
				t => t.UserAccount.UserAccountID, null, OrderByDirection.Ascending);

			var userList = new List<JobAssignmentGroup>();

			return new CachedCollection<JobAssignmentGroup>(userList, orderByInsertionStrategy);
		}

		public AddJobAssignmentGroupViewModel()
		{
			APL.I.AuthenticationSuccess += onAuthenticated;
		}

		private void onAuthenticated(UserAccount account)
		{
			InvalidateProperty(AccountsProperty);
		}
	}
}
 