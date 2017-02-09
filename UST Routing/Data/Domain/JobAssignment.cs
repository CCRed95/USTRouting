using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using Caliburn.Micro;
using Core.Data;
using Core.Data.CachedObjects;
using Core.Extensions;
using UST_Routing.Data.Persistance;

namespace UST_Routing.Data.Domain
{

	public partial class JobAssignment : LinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();


		[ValueDependencyTriggers("FlexTeams", "CurrentDailyTeamCount")]
		public static LinqProperty<JobAssignment, int> TotalMembersProperty =
			LinqPropertyBase.Register<JobAssignment, int>(TotalMembersEvaluator);

		public int TotalMembers => TotalMembersProperty.GetValue(this);

		private static int TotalMembersEvaluator(JobAssignment i)
		{
			return i.FlexTeams + i.CurrentDailyTeamCount;
		}

		public JobAssignment(City city,
			DateTime deadline,
			int currentDailyTeamCount,
			int flexTeams,
			bool hasStores,
			bool isAutoInput,
			IEnumerable<JobAssignmentCheckpoint> jobAssignmentCheckpoints) : this()
		{
			City = city;
			Deadline = deadline;
			CurrentDailyTeamCount = currentDailyTeamCount;
			FlexTeams = flexTeams;
			HasStores = hasStores;
			IsAutoInput = isAutoInput;

			var checkpoints = new EntitySet<JobAssignmentCheckpoint>();
			checkpoints.Assign(jobAssignmentCheckpoints);
			JobAssignmentCheckpoints = checkpoints;
		}
	}
	public partial class JobAssignment : IJobAssignmentQueryable
	{
		JobAssignmentGroup IJobAssignmentQueryable.__JobAssignmentGroup
			=> new Ref<int, JobAssignmentGroup>(JobAssignmentGroupMemberID, APL.I.FetchJobAssignmentGroup);

		UserAccount IJobAssignmentQueryable.__OwnerUserAccount 
			=> new Ref<JobAssignmentGroup, UserAccount>(JobAssignmentGroup, o => o.UserAccount);

		BindableCollection<JobAssignmentCheckpoint> IJobAssignmentQueryable.__JobAssignmentCheckpoints
			=> new Ref<int, BindableCollection<JobAssignmentCheckpoint>>(JobAssignmentID,
				o => APL.I.GetJobAssignmentCheckpoints(o).ToBindable());

		City IJobAssignmentQueryable.__City => new Ref<int, City>(AssociatedCityID, APL.I.FetchCity);
	}
}
