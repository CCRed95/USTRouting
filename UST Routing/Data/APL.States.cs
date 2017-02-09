using System;
using System.Data.Linq.SqlClient;
using System.Linq;
using JetBrains.Annotations;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data
{
	public partial class APL
	{
		public State AddState(State state)
		{
			using (var context = ctx)
			{
				return AddStateImpl(context, state);
			}
		}
		protected State AddStateImpl(
			USTDataContext context,
			State state, 
			bool deferSubmitChanges = false)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			context.States.InsertOnSubmit(state);
			if(!deferSubmitChanges)
			{
				context.SubmitChanges();
			}
			return state;
		}

		public State[] GetAllStates()
		{
			using (var context = new USTDataContext())
			{
				return context.States.ToArray();
			}
		}


		[CanBeNull]
		public State FetchState(int stateID)
		{
			using (var context = ctx)
			{
				return FetchStateImpl(context, stateID);
			}
		}
		[CanBeNull]
		protected State FetchStateImpl(
			USTDataContext context,
			int stateID)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			return context.States.SingleOrDefault(t => t.StateID == stateID);
		}


		[CanBeNull]
		public State FetchStateByName(string stateName)
		{
			using (var context = ctx)
			{
				return FetchStateByNameImpl(context, stateName);
			}
		}
		[CanBeNull]
		public State FetchStateByNameCaseInsensitive(string stateName)
		{
			using (var context = ctx)
			{
				return FetchStateByNameImpl(context, stateName, true);
			}
		}
		[CanBeNull]
		protected State FetchStateByNameImpl(
			USTDataContext context,
			string stateName,
			bool ignoreCase = false)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			if (ignoreCase)
				return context.States.SingleOrDefault(t => SqlMethods.Like(t.StateName, stateName));
			return context.States.SingleOrDefault(t => t.StateName == stateName);
		}


		[CanBeNull]
		public State FetchStateByAbbreviation(string abbreviation)
		{
			using (var context = ctx)
			{
				return FetchStateByAbbreviationImpl(context, abbreviation);
			}
		}
		[CanBeNull]
		public State FetchStateByAbbreviationCaseInsensitive(string abbreviation)
		{
			using (var context = ctx)
			{
				return FetchStateByAbbreviationImpl(context, abbreviation, true);
			}
		}
		[CanBeNull]
		protected State FetchStateByAbbreviationImpl(
			USTDataContext context,
			string abbreviation,
			bool ignoreCase = false)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			return context.States.SingleOrDefault(t => t.Abbreviation == abbreviation);
		}
	}
}
