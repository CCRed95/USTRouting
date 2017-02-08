using System;
using System.Collections.Generic;
using System.Linq;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data.ProjectedTypes
{
	public class FrozenJobAssignmentGroup
	{
		public UserAccount UserAccountFrozen { get; }
		public List<JobAssignment> JobAssignmentsFrozen { get; } 

		public FrozenJobAssignmentGroup(USTDataContext context, JobAssignmentGroup group)
		{
			UserAccountFrozen = group.UserAccount;
			JobAssignmentsFrozen = group.JobAssignments.ToList();

			foreach (var i in JobAssignmentsFrozen)
			{
				i.FreezeEntity();
			}
		}
	}
}
