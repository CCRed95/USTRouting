using System;
using System.Data;
using System.Linq;
using Caliburn.Micro;
using Core.Data;
using Core.Data.CachedObjects;
using Core.Extensions;
using UST_Routing.Data.Persistance;

namespace UST_Routing.Data.Domain
{
	public partial class JobAssignmentGroup : LinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();

	}
	public partial class JobAssignmentGroup : IJobAssignmentGroupQueryable
	{
		UserAccount IJobAssignmentGroupQueryable.__UserAccount
			=> new Ref<int, UserAccount>(AssociatedAccountID, APL.I.FetchUserAccount);
		
		BindableCollection<JobAssignment> IJobAssignmentGroupQueryable.__JobAssignments
			=> new Ref<int, BindableCollection<JobAssignment>>(AssignmentGroupID, o =>
			{
				var assignmentGroup = APL.I.FetchJobAssignmentGroup(o);
				if (assignmentGroup == null)
					throw new DataException();

				return assignmentGroup.JobAssignments.ToBindable();
			});
	}
}
