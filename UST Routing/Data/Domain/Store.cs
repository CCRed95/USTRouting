using Core.Data;
using Core.Data.CachedObjects;
using Core.Extensions;

namespace UST_Routing.Data.Domain
{
	public partial class Store : LinqEntity
	{
		//ReSharper disable once UnusedMember.Local
		partial void OnLoaded() => ((ILinqEntity)this).OnLoaded();

		[ValueDependencyTriggers("StreetAddress", "AddressLine2", "ZipCode", "City")]
		public static LinqProperty<Store, string> FormattedMailingAddressProperty =
			LinqPropertyBase.Register<Store, string>(FormattedMailingAddressEvaluator);

		public string FormattedMailingAddress => FormattedMailingAddressProperty.GetValue(this);
		
		private static string FormattedMailingAddressEvaluator(Store i)
		{
			var mailingAddress = $"{i.StreetAddress}";
			if (!i.AddressLine2.IsNullOrEmpty())
			{
				mailingAddress += $", {i.AddressLine2}";
			}
			mailingAddress += $", {i.City.CityName} {i.City.State.StateName}, {i.ZipCode}";
			return mailingAddress;
		}

		public Store(int legacyStoreID,
			City city,
			string streetAddress,
			int zipCode,
			string addressLine2 = null) : this()
		{
			LegacyStoreID = legacyStoreID;
			City = city;
			StreetAddress = streetAddress;
			ZipCode = zipCode;
			AddressLine2 = addressLine2;
		}
	}
}
