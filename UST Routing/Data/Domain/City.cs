
using Core.Data.CachedObjects;

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
			string state = null,
			long? latitude = null,
			long? longitude = null,
			int? timeZoneOffset = null,
			bool inferred = false)
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
}
