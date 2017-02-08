using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Caliburn.Micro;
using Core.Controls;
using Core.Data.CachedCollections;
using Core.Data.CachedCollections.Sorting;
using Core.Data.CachedObjects;
using UST_Routing.Data;
using UST_Routing.Data.Domain;

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

		


		public static LinqProperty<MainViewModel, AddJobAssignmentGroupViewModel> AddJobAssignmentGroupViewProperty =
			LinqPropertyBase.Register<MainViewModel, AddJobAssignmentGroupViewModel>(AddJobAssignmentGroupViewEvaluator);

		public AddJobAssignmentGroupViewModel AddJobAssignmentGroupView => AddJobAssignmentGroupViewProperty.GetValue(this);

		private static AddJobAssignmentGroupViewModel AddJobAssignmentGroupViewEvaluator(MainViewModel i)
		{
			return new AddJobAssignmentGroupViewModel();
		}


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
}
