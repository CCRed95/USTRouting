using Core.Data;
using Core.Data.CachedObjects;

namespace UST_Routing.Data.Domain
{
	public partial class State : LinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();

		public static State Unknown => new Ref<string, State>("XX", APL.I.FetchStateByAbbreviationCaseInsensitive);

		public State(string abbreviation, string stateName) : this()
		{
			Abbreviation = abbreviation;
			StateName = stateName;
		}
	}
}
