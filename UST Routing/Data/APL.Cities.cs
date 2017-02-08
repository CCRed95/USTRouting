using System;
using System.Linq;
using JetBrains.Annotations;
using UST_Routing.Data.Domain;

namespace UST_Routing.Data
{
	public partial class APL
	{
		public City AddCity(City city)
		{
			using (var context = ctx)
			{
				return AddCityImpl(context, city);
			}
		}
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
	



		public City[] GetGlobalCities()
		{
			using (var context = new USTDataContext())
			{
				return context.Cities.ToArray();
			}
		}

		public City GetCity(string cityName)
		{
			using (var context = new USTDataContext())
			{
				return context.Cities.Single(user => user.CityName == cityName);
			}
		}
		public City GetCity(string cityName, USTDataContext context)
		{
			return context.Cities.Single(user => user.CityName == cityName);
		}

		public bool TryGetCity(string cityName, out City city)
		{
			try
			{
				using (var context = new USTDataContext())
				{
					city = context.Cities.Single(user => user.CityName == cityName);
				}
				return true;
			}
			catch
			{
				city = default(City);
				return false;
			}

		}

		public City GetCity(int cityID)
		{
			using (var context = new USTDataContext())
			{
				return context.Cities.Single(user => user.CityID == cityID);
			}
		}

	}
}
