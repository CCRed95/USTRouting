using System.Linq;
using Caliburn.Micro;
using Core.Data.CachedObjects;

namespace UST_Routing.Data.Domain
{
	public partial class JobAssignmentGroup : LinqEntity, IFreezableLinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();

		public UserAccount Frozen_UserAccount { get; private set; }

		public BindableCollection<JobAssignment> Frozen_JobAssignments { get; private set; }

		public void FreezeEntity()
		{
			Frozen_UserAccount = UserAccount;
			var jobAssignments = JobAssignments.ToArray();
			Frozen_JobAssignments = new BindableCollection<JobAssignment>(jobAssignments);
			foreach (var i in Frozen_JobAssignments)
			{
				i.FreezeEntity();
			}
		}
	}
}
