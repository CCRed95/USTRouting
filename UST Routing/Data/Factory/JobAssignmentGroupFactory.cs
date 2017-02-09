using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data.Factory
{
	public class JobAssignmentGroupFactory
	{
		private JobAssignmentGroup composite;

		public JobAssignmentGroupFactory()
		{
			
		}

		public void Add(JobAssignment jobAssignment)
		{
			if (composite == null)
				InitializeContainerElement();

			composite.JobAssignments.Add(jobAssignment);
		}

		private void InitializeContainerElement()
		{
			var value = new JobAssignmentGroup
			{
				UserAccount = APL.I.CurrentUserAccount
			};
			composite = APL.I.AddJobAssignmentGroup(value);
		}
	}
}
