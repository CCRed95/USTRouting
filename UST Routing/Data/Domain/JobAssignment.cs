using System;
using System.Linq;
using Caliburn.Micro;
using Core.Data;
using Core.Data.CachedObjects;

namespace UST_Routing.Data.Domain
{
	public partial class JobAssignment : LinqEntity, IFreezableLinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();

		public BindableCollection<JobAssignmentCheckpoint> Frozen_JobAssignmentCheckpoints { get; private set; }

		public City Frozen_City { get; private set; }

		[ValueDependencyTriggers("FlexTeams", "CurrentDailyTeamCount")]
		public static LinqProperty<JobAssignment, int> TotalMembersProperty =
			LinqPropertyBase.Register<JobAssignment, int>(TotalMembersEvaluator);

		public int TotalMembers => TotalMembersProperty.GetValue(this);

		public JobAssignment(City city, DateTime deadline, int currentDailyTeamCount, int flexTeams, bool hasStores, bool isAutoInput)
		{
			City = city;
			Deadline = deadline;
			CurrentDailyTeamCount = currentDailyTeamCount;
			FlexTeams = flexTeams;
			HasStores = hasStores;
			IsAutoInput = isAutoInput;
		}

		private static int TotalMembersEvaluator(JobAssignment i)
		{
			return i.FlexTeams + i.CurrentDailyTeamCount;
		}
		public void FreezeEntity()
		{
			var checkpoints = JobAssignmentCheckpoints.ToArray();
			Frozen_JobAssignmentCheckpoints = new BindableCollection<JobAssignmentCheckpoint>(checkpoints);
			Frozen_City = APL.I.GetCity(City.CityID);

		}
	}
}
