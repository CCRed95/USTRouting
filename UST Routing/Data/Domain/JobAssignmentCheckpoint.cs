using System;
using Core.Data;
using Core.Data.CachedObjects;
using UST_Routing.Data.ProjectedTypes;

namespace UST_Routing.Data.Domain
{
	public partial class JobAssignmentCheckpoint : LinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();

		[ValueDependencyTriggers("CheckPointType")]
		public static LinqProperty<JobAssignmentCheckpoint, CheckpointType> CheckpointTypeEnumProperty =
			LinqPropertyBase.Register<JobAssignmentCheckpoint, CheckpointType>(CheckpointTypeEnumEvaluator);

		public CheckpointType CheckpointTypeEnum => CheckpointTypeEnumProperty.GetValue(this);

		//Assign(jobAssignmentCheckpoints);
		public JobAssignmentCheckpoint(DateTime checkpointDeadline, CheckpointType type) : this()
		{
			//JobAssignment = jobAssignment;
			CheckPointType = (int)type;
			CheckpointDeadline = checkpointDeadline;
		}

		private static CheckpointType CheckpointTypeEnumEvaluator(JobAssignmentCheckpoint i)
		{
			return (CheckpointType)i.CheckPointType;
		}
	}
}
