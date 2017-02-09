
using Core.Data;
using Core.Data.CachedObjects;
using UST_Routing.Data.Persistance;

namespace UST_Routing.Data.Domain
{
	public partial class City : LinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();
		

		public City(string cityName,
			string imagePath,
			int legacyLocationID,
			string legacyLocationMoniker,
			State state,
			long? latitude = null,
			long? longitude = null,
			int? timeZoneOffset = null,
			bool inferred = false) : this()
		{
			CityName = cityName;
			ImagePath = imagePath;
			LegacyLocationID = legacyLocationID;
			LegacyLocationMoniker = legacyLocationMoniker;
			State = state;
			Latitude = latitude;
			Longitude = longitude;
			TimeZoneOffset = timeZoneOffset;
			Inferred = inferred;
		}
	}
	public partial class City : ICityQueryable
	{
		State ICityQueryable.__State => new Ref<int, State>(CityID, APL.I.FetchState);
	}
}
