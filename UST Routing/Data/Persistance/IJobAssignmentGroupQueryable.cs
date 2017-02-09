using Caliburn.Micro;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data.Persistance
{
	public interface IJobAssignmentGroupQueryable
	{
		UserAccount __UserAccount { get; }

		BindableCollection<JobAssignment> __JobAssignments { get; }
	}
}
