using System;
using System.Collections.Generic;
using System.Linq;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data
{
	public partial class APL
	{ 
		public JobAssignment[] GetJobAssignments(int jobAssignmentID)
		{
			using (var context = ctx)
			{
				return GetJobAssignmentsImpl(context, jobAssignmentID).ToArray();
			}
		}
		protected IQueryable<JobAssignment> GetJobAssignmentsImpl(
			USTDataContext context,
			int jobAssignmentID)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			return context.JobAssignments.Where(t => t.JobAssignmentID == jobAssignmentID);
		}


	}
}
