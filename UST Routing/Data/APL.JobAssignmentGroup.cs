using System;
using System.Data;
using System.Linq;
using Core.Extensions;
using JetBrains.Annotations;
using MySql.Data.MySqlClient;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data
{
	public partial class APL
	{
		public JobAssignmentGroup AddJobAssignmentGroup(/*JobAssignmentGroup jobAssignmentGroup*/)
		{
			using (var context = ctx)
			{
				var jobAssignmentGroup = new JobAssignmentGroup();
				var myaccount = FetchUserFromUsernameAccountImpl(context, "admin");
				jobAssignmentGroup.UserAccount = myaccount;

				var city = I.FetchCityByNameImpl(context, "Memphis");
				var firstJob = new JobAssignment();
				firstJob.City = city;
				var today = DateTime.Today.Date;
				firstJob.Deadline = today.AtTime("6:20 PM");
				firstJob.CurrentDailyTeamCount = 5;
				firstJob.FlexTeams = 0;
				firstJob.HasStores = true;
				firstJob.IsSoftRoute = false;

				firstJob.JobAssignmentCheckpoints.AddRange(new[]
				{
					new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
					new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
					new JobAssignmentCheckpoint(today.AtTime("6:20 PM"), CheckpointType.Export),
					new JobAssignmentCheckpoint(today.AtTime("6:35 PM"), CheckpointType.ScheduleMailText),
					new JobAssignmentCheckpoint(today.AtTime("6:50 PM"), CheckpointType.ScheduleCalls),
					new JobAssignmentCheckpoint(today.AtTime("7:15 PM"), CheckpointType.UnconfirmedCalls),
					new JobAssignmentCheckpoint(today.AtTime("7:40 PM"), CheckpointType.UnconfirmedCallsII),
				});
				jobAssignmentGroup.JobAssignments.Add(firstJob);
				return AddJobAssignmentGroupImpl(context, jobAssignmentGroup);
			}
		}

		public JobAssignmentGroup AddJobAssignmentGroup(JobAssignmentGroup jobAssignmentGroup)
		{
			using (var context = ctx)
			{
				return AddJobAssignmentGroupImpl(context, jobAssignmentGroup);
			}
		}
		protected JobAssignmentGroup AddJobAssignmentGroupImpl(
			USTDataContext context,
			JobAssignmentGroup jobAssignmentGroup,
			bool deferSubmitChanges = false)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			context.JobAssignmentGroups.InsertOnSubmit(jobAssignmentGroup);
			if (!deferSubmitChanges)
			{
				context.SubmitChanges();
			}
			return jobAssignmentGroup;
		}



		[CanBeNull]
		public JobAssignmentGroup FetchJobAssignmentGroup(int jobAssignmentGroupID)
		{
			using (var context = ctx)
			{
				return FetchJobAssignmentGroupImpl(context, jobAssignmentGroupID);
			}
		}
		[CanBeNull]
		protected JobAssignmentGroup FetchJobAssignmentGroupImpl(
			USTDataContext context,
			int jobAssignmentGroupID)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			return context.JobAssignmentGroups.SingleOrDefault(t => t.AssignmentGroupID == jobAssignmentGroupID);
		}
	}
}
