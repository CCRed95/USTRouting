//using System;
//using System.CodeDom;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Core.Extensions;
//using Microsoft.VisualBasic.FileIO;
//using UST_Routing.Data.Domain;

//namespace UST_Routing.Data
//{

//	public class StoreDataReader
//	{
//		protected enum CSVColumnSchema
//		{
//			Store,
//			StreetAddress,
//			AddressLine2,
//			CityName,
//			StateAbbreviation,
//			ZipCode
//		}

//		const int unparsedInt = -1;
//		const string unparsedString = "#unparsed";

//		public static Store ParseStoreEntryFromCSV(string csvLine)
//		{
//			IList<string> recordDataParts;
//			var csvParser = new TextFieldParser(new StringReader(csvLine)) { HasFieldsEnclosedInQuotes = true };
//			csvParser.SetDelimiters(",");
//			recordDataParts = csvParser.ReadFields();
//			csvParser.Close();
//			csvParser.Dispose();



//			var _legacyStoreID = unparsedInt;
//			var _streetAddress = unparsedString;
//			string _addressLine2 = null;
//			var _cityName = unparsedString;
//			var _stateAbbreviation = unparsedString;
//			var _zipcode = unparsedInt;


//			foreach (var csvColumn in EnumExtensions.GetValues<CSVColumnSchema>())
//			{
//				var recordDataPart = recordDataParts[(int)csvColumn];

//				switch (csvColumn)
//				{
//					case CSVColumnSchema.Store:
//						{
//							_legacyStoreID = Convert.ToInt32(recordDataPart);
//							break;
//						}
//					case CSVColumnSchema.StreetAddress:
//						{
//							_streetAddress = recordDataPart;
//							break;
//						}
//					case CSVColumnSchema.AddressLine2:
//						{
//							_addressLine2 = recordDataPart;
//							break;
//						}

//					case CSVColumnSchema.CityName:
//						{
//							_cityName = recordDataPart;
//							break;
//						}
//					case CSVColumnSchema.StateAbbreviation:
//						{
//							_stateAbbreviation = recordDataPart;
//						}
//						break;

//					case CSVColumnSchema.ZipCode:
//						{
//							_zipcode = Convert.ToInt32(recordDataPart);
//						}
//						break;
//					default:
//						throw new ArgumentOutOfRangeException();
//				}
//			}
//			throwIfUnparsed(_legacyStoreID);
//			throwIfUnparsed(_streetAddress);
//			throwIfUnparsed(_cityName);
//			throwIfUnparsed(_stateAbbreviation);
//			throwIfUnparsed(_zipcode);

//			City associatedCity;
//			if (!APLOLD.I.TryGetCity(_cityName, out associatedCity))
//			{
//				throw new NotSupportedException("city not found");
//			}

//			return new Store
//			{
//				LegacyStoreID = _legacyStoreID,
//				AssociatedCityID = associatedCity.CityID,
//				StreetAddress = _streetAddress,
//				AddressLine2 = _addressLine2,
//				ZipCode = _zipcode
//			};
//		}

//		private static void throwIfUnparsed(object value)
//		{
//			var valueType = value.GetType();
//			if (valueType == typeof(string))
//			{
//				if ((string)value == unparsedString)
//					throw new NotSupportedException("string is unparsed");
//			}
//			else if (valueType == typeof(int))
//			{
//				if ((int)value == unparsedInt)
//					throw new NotSupportedException("int is unparsed");
//			}
//		}
//	}
//}
