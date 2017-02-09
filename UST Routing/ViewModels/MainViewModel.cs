using System;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Windows.Input;
using Caliburn.Micro;
using Core.Controls;
using Core.Data.CachedCollections;
using Core.Data.CachedCollections.Sorting;
using Core.Data.CachedObjects;
using Core.Extensions;
using UST_Routing.Data;
using UST_Routing.Data.Domain;
using UST_Routing.Data.ProjectedTypes;

namespace UST_Routing.ViewModels
{
	public class MainViewModel : LinqEntityViewModel
	{
		public enum AddJobAssignmentGroupViewStates
		{
			AddJobAssignmentGroupViewContractedState,
			AddJobAssignmentGroupViewExpandedState
		}

		private AddJobAssignmentGroupViewStates addJobAssignmentGroupViewState = AddJobAssignmentGroupViewStates.AddJobAssignmentGroupViewContractedState;
		public AddJobAssignmentGroupViewStates AddJobAssignmentGroupViewState
		{
			get { return addJobAssignmentGroupViewState; }
			set
			{
				addJobAssignmentGroupViewState = value;
				NotifyOfPropertyChange(() => AddJobAssignmentGroupViewState);
			}
		}

		//public ICommand ContractAddJobAssignmentGroupViewCommand => new FlexCommand(
		//	o => {
		//	AddJobAssignmentGroupViewState = AddJobAssignmentGroupViewStates.AddJobAssignmentGroupViewContractedState;
		//	});

		//public ICommand ExpandAddJobAssignmentGroupViewCommand => new FlexCommand(
		//	o =>
		//	{

		//		var io = APLOLD.I.GetFrozenLastAssignmentGroup(APLOLD.I.CurrentUser);

		//		AddJobAssignmentGroupViewState = AddJobAssignmentGroupViewStates.AddJobAssignmentGroupViewExpandedState;
		//	});

		//public ICommand LoadDataCommand => new FlexCommand(
		//	o =>
		//	{
		//		var io = APLOLD.I.GetFrozenLastAssignmentGroup(APLOLD.I.CurrentUser);
		//		JobAssignmentGroup = io;
		//	});




		//public static LinqProperty<MainViewModel, AddJobAssignmentGroupViewModel> AddJobAssignmentGroupViewProperty =
		//	LinqPropertyBase.Register<MainViewModel, AddJobAssignmentGroupViewModel>(AddJobAssignmentGroupViewEvaluator);

		//public AddJobAssignmentGroupViewModel AddJobAssignmentGroupView => AddJobAssignmentGroupViewProperty.GetValue(this);

		//private static AddJobAssignmentGroupViewModel AddJobAssignmentGroupViewEvaluator(MainViewModel i)
		//{
		//	return new AddJobAssignmentGroupViewModel();
		//}


		private JobAssignmentGroup jobAssignmentGroup;
		public JobAssignmentGroup JobAssignmentGroup
		{
			get { return jobAssignmentGroup; }
			set
			{
				jobAssignmentGroup = value;
				NotifyOfPropertyChange(() => JobAssignmentGroup);
			}
		}


		protected AppRootViewModel _parentViewModel;
		public MainViewModel(AppRootViewModel parentViewModel)
		{
			_parentViewModel = parentViewModel;
			APL.I.AuthenticationSuccess += OnAuthenticationSuccess;
		}

		private void OnAuthenticationSuccess(UserAccount P1)
		{
			APL.I.AddJobAssignmentGroup();
			//APL.I.BeginContextTransaction();

			//JobAssignmentGroup = new JobAssignmentGroup
			//{
			//	UserAccount = APL.I.CurrentUserAccount,
			//	JobAssignments = new EntitySet<JobAssignment>
			//	{
			//		new JobAssignment(
			//			APL.I.FetchCityByName("Memphis"),
			//			today.AtTime("6:20 PM"),
			//			5, 0, true, false, new []
			//			{
			//				new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//				new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//				new JobAssignmentCheckpoint(today.AtTime("6:20 PM"), CheckpointType.Export),
			//				new JobAssignmentCheckpoint(today.AtTime("6:35 PM"), CheckpointType.ScheduleMailText),
			//				new JobAssignmentCheckpoint(today.AtTime("6:50 PM"), CheckpointType.ScheduleCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("7:15 PM"), CheckpointType.UnconfirmedCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("7:40 PM"), CheckpointType.UnconfirmedCallsII),
			//			}),
			//		new JobAssignment(
			//			APL.I.FetchCityByName("Knoxville"),
			//			today.AtTime("7:20 PM"),
			//			1, 1, true, false, new []
			//			{
			//				new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//				new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//				new JobAssignmentCheckpoint(today.AtTime("7:20 PM"), CheckpointType.Export),
			//				new JobAssignmentCheckpoint(today.AtTime("7:35 PM"), CheckpointType.ScheduleMailText),
			//				new JobAssignmentCheckpoint(today.AtTime("7:50 PM"), CheckpointType.ScheduleCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("8:15 PM"), CheckpointType.UnconfirmedCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("8:40 PM"), CheckpointType.UnconfirmedCallsII),
			//			}),
			//		new JobAssignment(
			//			APL.I.FetchCityByName("Nashville"),
			//			today.AtTime("7:20 PM"),
			//			3, 0, true, false, new []
			//			{
			//				new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//				new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//				new JobAssignmentCheckpoint(today.AtTime("7:20 PM"), CheckpointType.Export),
			//				new JobAssignmentCheckpoint(today.AtTime("7:35 PM"), CheckpointType.ScheduleMailText),
			//				new JobAssignmentCheckpoint(today.AtTime("7:50 PM"), CheckpointType.ScheduleCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("8:15 PM"), CheckpointType.UnconfirmedCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("8:40 PM"), CheckpointType.UnconfirmedCallsII),
			//			}),
			//		new JobAssignment(
			//			APL.I.FetchCityByName("Beaumont"),
			//			today.AtTime("8:20 PM"),
			//			7, 1, false, false, new []
			//			{
			//				new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//				new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//				new JobAssignmentCheckpoint(today.AtTime("8:20 PM"), CheckpointType.Export),
			//				new JobAssignmentCheckpoint(today.AtTime("8:35 PM"), CheckpointType.ScheduleMailText),
			//				new JobAssignmentCheckpoint(today.AtTime("8:50 PM"), CheckpointType.ScheduleCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("9:15 PM"), CheckpointType.UnconfirmedCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("9:40 PM"), CheckpointType.UnconfirmedCallsII),
			//			}),
			//		new JobAssignment(
			//			APL.I.FetchCityByName("Lafayette"),
			//			today.AtTime("8:20 PM"),
			//			4, 0, false, true, new []
			//			{
			//				new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//				new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//				new JobAssignmentCheckpoint(today.AtTime("8:20 PM"), CheckpointType.Export),
			//				new JobAssignmentCheckpoint(today.AtTime("8:35 PM"), CheckpointType.ScheduleMailText),
			//				new JobAssignmentCheckpoint(today.AtTime("8:50 PM"), CheckpointType.ScheduleCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("9:15 PM"), CheckpointType.UnconfirmedCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("9:40 PM"), CheckpointType.UnconfirmedCallsII),
			//			}),
			//		new JobAssignment(
			//			APL.I.FetchCityByName("Amarillo"),
			//			today.AtTime("8:20 PM"),
			//			2, 1, false, false, new []
			//			{
			//				new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//				new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//				new JobAssignmentCheckpoint(today.AtTime("8:20 PM"), CheckpointType.Export),
			//				new JobAssignmentCheckpoint(today.AtTime("8:35 PM"), CheckpointType.ScheduleMailText),
			//				new JobAssignmentCheckpoint(today.AtTime("8:50 PM"), CheckpointType.ScheduleCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("9:15 PM"), CheckpointType.UnconfirmedCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("9:40 PM"), CheckpointType.UnconfirmedCallsII),
			//			}),
			//		new JobAssignment(
			//			APL.I.FetchCityByName("Baton Rouge"),
			//			today.AtTime("8:20 PM"),
			//			2, 0, false, false, new []
			//			{
			//				new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//				new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//				new JobAssignmentCheckpoint(today.AtTime("8:20 PM"), CheckpointType.Export),
			//				new JobAssignmentCheckpoint(today.AtTime("8:35 PM"), CheckpointType.ScheduleMailText),
			//				new JobAssignmentCheckpoint(today.AtTime("8:50 PM"), CheckpointType.ScheduleCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("9:15 PM"), CheckpointType.UnconfirmedCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("9:40 PM"), CheckpointType.UnconfirmedCallsII),
			//			}),
			//		new JobAssignment(
			//			APL.I.FetchCityByName("Tucson"),
			//			today.AtTime("9:20 PM"),
			//			2, 1, true, false, new []
			//			{
			//				new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//				new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//				new JobAssignmentCheckpoint(today.AtTime("10:20 PM"), CheckpointType.Export),
			//				new JobAssignmentCheckpoint(today.AtTime("10:35 PM"), CheckpointType.ScheduleMailText),
			//				new JobAssignmentCheckpoint(today.AtTime("11:15 PM"), CheckpointType.ScheduleCalls),
			//				new JobAssignmentCheckpoint(today.AtTime("11:40 PM"), CheckpointType.UnconfirmedCalls),
			//			})
			//	}
			//};
			//JobAssignmentGroup = new JobAssignmentGroup
			//{
			//	UserAccount = APL.I.CurrentUserAccount,
			//	JobAssignments = new EntitySet<JobAssignment>(OnAdd, OnRemove)


			//new JobAssignment(
			//	APL.I.FetchCityByName("Knoxville"),
			//	today.AtTime("7:20 PM"),
			//	1, 1, true, false, new []
			//	{
			//		new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//		new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//		new JobAssignmentCheckpoint(today.AtTime("7:20 PM"), CheckpointType.Export),
			//		new JobAssignmentCheckpoint(today.AtTime("7:35 PM"), CheckpointType.ScheduleMailText),
			//		new JobAssignmentCheckpoint(today.AtTime("7:50 PM"), CheckpointType.ScheduleCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("8:15 PM"), CheckpointType.UnconfirmedCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("8:40 PM"), CheckpointType.UnconfirmedCallsII),
			//	}),
			//new JobAssignment(
			//	APL.I.FetchCityByName("Nashville"),
			//	today.AtTime("7:20 PM"),
			//	3, 0, true, false, new []
			//	{
			//		new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//		new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//		new JobAssignmentCheckpoint(today.AtTime("7:20 PM"), CheckpointType.Export),
			//		new JobAssignmentCheckpoint(today.AtTime("7:35 PM"), CheckpointType.ScheduleMailText),
			//		new JobAssignmentCheckpoint(today.AtTime("7:50 PM"), CheckpointType.ScheduleCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("8:15 PM"), CheckpointType.UnconfirmedCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("8:40 PM"), CheckpointType.UnconfirmedCallsII),
			//	}),
			//new JobAssignment(
			//	APL.I.FetchCityByName("Beaumont"),
			//	today.AtTime("8:20 PM"),
			//	7, 1, false, false, new []
			//	{
			//		new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//		new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//		new JobAssignmentCheckpoint(today.AtTime("8:20 PM"), CheckpointType.Export),
			//		new JobAssignmentCheckpoint(today.AtTime("8:35 PM"), CheckpointType.ScheduleMailText),
			//		new JobAssignmentCheckpoint(today.AtTime("8:50 PM"), CheckpointType.ScheduleCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("9:15 PM"), CheckpointType.UnconfirmedCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("9:40 PM"), CheckpointType.UnconfirmedCallsII),
			//	}),
			//new JobAssignment(
			//	APL.I.FetchCityByName("Lafayette"),
			//	today.AtTime("8:20 PM"),
			//	4, 0, false, true, new []
			//	{
			//		new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//		new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//		new JobAssignmentCheckpoint(today.AtTime("8:20 PM"), CheckpointType.Export),
			//		new JobAssignmentCheckpoint(today.AtTime("8:35 PM"), CheckpointType.ScheduleMailText),
			//		new JobAssignmentCheckpoint(today.AtTime("8:50 PM"), CheckpointType.ScheduleCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("9:15 PM"), CheckpointType.UnconfirmedCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("9:40 PM"), CheckpointType.UnconfirmedCallsII),
			//	}),
			//new JobAssignment(
			//	APL.I.FetchCityByName("Amarillo"),
			//	today.AtTime("8:20 PM"),
			//	2, 1, false, false, new []
			//	{
			//		new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//		new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//		new JobAssignmentCheckpoint(today.AtTime("8:20 PM"), CheckpointType.Export),
			//		new JobAssignmentCheckpoint(today.AtTime("8:35 PM"), CheckpointType.ScheduleMailText),
			//		new JobAssignmentCheckpoint(today.AtTime("8:50 PM"), CheckpointType.ScheduleCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("9:15 PM"), CheckpointType.UnconfirmedCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("9:40 PM"), CheckpointType.UnconfirmedCallsII),
			//	}),
			//new JobAssignment(
			//	APL.I.FetchCityByName("Baton Rouge"),
			//	today.AtTime("8:20 PM"),
			//	2, 0, false, false, new []
			//	{
			//		new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//		new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//		new JobAssignmentCheckpoint(today.AtTime("8:20 PM"), CheckpointType.Export),
			//		new JobAssignmentCheckpoint(today.AtTime("8:35 PM"), CheckpointType.ScheduleMailText),
			//		new JobAssignmentCheckpoint(today.AtTime("8:50 PM"), CheckpointType.ScheduleCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("9:15 PM"), CheckpointType.UnconfirmedCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("9:40 PM"), CheckpointType.UnconfirmedCallsII),
			//	}),
			//new JobAssignment(
			//	APL.I.FetchCityByName("Tucson"),
			//	today.AtTime("9:20 PM"),
			//	2, 1, true, false, new []
			//	{
			//		new JobAssignmentCheckpoint(today.AtTime("3:15 PM"), CheckpointType.PreRouteMailCall),
			//		new JobAssignmentCheckpoint(today.AtTime("5:15 PM"), CheckpointType.PreRouteUnconfirmed),
			//		new JobAssignmentCheckpoint(today.AtTime("10:20 PM"), CheckpointType.Export),
			//		new JobAssignmentCheckpoint(today.AtTime("10:35 PM"), CheckpointType.ScheduleMailText),
			//		new JobAssignmentCheckpoint(today.AtTime("11:15 PM"), CheckpointType.ScheduleCalls),
			//		new JobAssignmentCheckpoint(today.AtTime("11:40 PM"), CheckpointType.UnconfirmedCalls),
			//	})


		}

		//private void OnRemove(JobAssignment Assignment)
		//{
		//}

		//private void OnAdd(JobAssignment Assignment)
		//{
		//}

		//var assignmentGroup = APL.I.AddJobAssignmentGroup(JobAssignmentGroup);
		//APL.I.EndContextTransaction();
		}

	//public ICommand BeginAddJobAssignmentGroupCommand => new FlexCommand(
	//	o =>
	//	{

	//	},
	//	o =>
	//	{
	//		return true;
	//	});
}
