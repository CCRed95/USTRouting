using System;
using System.Linq;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data
{
	public partial class APL
	{
		public JobAssignmentCheckpoint[] GetJobAssignmentCheckpoints(int jobAssignmentID)
		{
			using (var context = ctx)
			{
				return GetJobAssignmentCheckpointsImpl(context, jobAssignmentID).ToArray();
			}
		}
		protected IQueryable<JobAssignmentCheckpoint> GetJobAssignmentCheckpointsImpl(
			USTDataContext context,
			int jobAssignmentID)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			return context.JobAssignmentCheckpoints.Where(t => t.AssociatedJobAssignmentID == jobAssignmentID);
		}
	}
}
