using Caliburn.Micro;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data.Persistance
{
	public interface IJobAssignmentQueryable
	{
		JobAssignmentGroup __JobAssignmentGroup { get; }

		UserAccount __OwnerUserAccount { get; }

		BindableCollection<JobAssignmentCheckpoint> __JobAssignmentCheckpoints { get; }

		City __City { get; }
	}
}
