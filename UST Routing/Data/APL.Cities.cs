using System;
using System.Data.Linq.SqlClient;
using System.Linq;
using JetBrains.Annotations;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data
{
	public partial class APL
	{
		[NotNull]
		public City AddCity(City city)
		{
			using (var context = ctx)
			{
				return AddCityImpl(context, city);
			}
		}
		[NotNull]
		protected City AddCityImpl(
			[NotNull] USTDataContext context,
			City city,
			bool deferSubmitChanges = false)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			context.Cities.InsertOnSubmit(city);
			if (!deferSubmitChanges)
			{
				context.SubmitChanges();
			}
			return city;
		}


		public City[] GetAllCities()
		{
			using (var context = ctx)
			{
				return context.Cities.ToArray();
			}
		}


		[CanBeNull]
		public City FetchCity(int cityID)
		{
			using (var context = ctx)
			{
				return FetchCityImpl(context, cityID);
			}
		}
		[CanBeNull]
		protected City FetchCityImpl(
			[NotNull] USTDataContext context,
			int cityID)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			return context.Cities.SingleOrDefault(t => t.CityID == cityID);
		}


		[CanBeNull]
		public City FetchCityByName(string cityName)
		{
			using (var context = ctx)
			{
				return FetchCityByNameImpl(context, cityName);
			}
		}
		[CanBeNull]
		public City FetchCityByNameCaseInsensitive(string cityName)
		{
			using (var context = ctx)
			{
				return FetchCityByNameImpl(context, cityName, true);
			}
		}
		[CanBeNull]
		protected City FetchCityByNameImpl(
			USTDataContext context,
			string cityName,
			bool ignoreCase = false)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			if (ignoreCase)
				return context.Cities.SingleOrDefault(t => SqlMethods.Like(t.CityName, cityName));
			return context.Cities.SingleOrDefault(t => t.CityName == cityName);
		}


		[CanBeNull]
		public City FetchCityByLegacyMonikerCaseInsensitive(string legacyCityMoniker)
		{
			using (var context = ctx)
			{
				return FetchCityByLegacyMonikerCaseInsensitiveImpl(context, legacyCityMoniker);
			}
		}
		[CanBeNull]
		protected City FetchCityByLegacyMonikerCaseInsensitiveImpl(
			USTDataContext context,
			string legacyCityMoniker)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			return context.Cities.SingleOrDefault(t => SqlMethods.Like(t.LegacyLocationMoniker, legacyCityMoniker));
		}


	}
}
