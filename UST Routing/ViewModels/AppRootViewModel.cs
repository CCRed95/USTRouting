using System.Text.RegularExpressions;
using Core.Data.CachedObjects;
using UST_Routing.Accounts;
using UST_Routing.Data;
using UST_Routing.Data.Domain;

namespace UST_Routing.ViewModels
{
	public class AppRootViewModel : LinqEntityViewModel
	{

		public enum AppModePages
		{
			LoginViewPage,
			RegisterViewPage,
			MainViewPage
		}

		private AppModePages appModePage = AppModePages.LoginViewPage;
		public AppModePages AppModePage
		{
			get { return appModePage; }
			set
			{
				appModePage = value;
				NotifyOfPropertyChange(() => AppModePage);
			}
		}


		public static LinqProperty<AppRootViewModel, LoginViewModel> LoginViewProperty =
			LinqPropertyBase.Register<AppRootViewModel, LoginViewModel>(LoginViewEvaluator);

		public LoginViewModel LoginView => LoginViewProperty.GetValue(this);

		private static LoginViewModel LoginViewEvaluator(AppRootViewModel i)
		{
			return new LoginViewModel(i);
		}

		
		public static LinqProperty<AppRootViewModel, RegisterViewModel> RegisterViewProperty =
			LinqPropertyBase.Register<AppRootViewModel, RegisterViewModel>(RegisterViewEvaluator);

		public RegisterViewModel RegisterView => RegisterViewProperty.GetValue(this);

		private static RegisterViewModel RegisterViewEvaluator(AppRootViewModel i)
		{
			return new RegisterViewModel(i);
		}
		

		public static LinqProperty<AppRootViewModel, MainViewModel> MainViewProperty =
			LinqPropertyBase.Register<AppRootViewModel, MainViewModel>(MainViewEvaluator);

		public MainViewModel MainView => MainViewProperty.GetValue(this);

		private static MainViewModel MainViewEvaluator(AppRootViewModel i)
		{
			return new MainViewModel(i);
		}


		public void LoginSuccessCallback()
		{
			AppModePage = AppModePages.MainViewPage;
		}

		public AppRootViewModel()
		{
			//var admin = APL.I.AddUserAccount(new UserAccount("admin", "admin@admin.com", "password", AccountType.Admin, "admin", "admin",
			//	"App Administrator"));
		}

		//		//var admin = APL.I.AddUserAccount(new UserAccount(
			//		//"admin", "1234", AccountType.Admin, "admin", "account"));
			//		//var j1 = APL.I.AddUserAccount(new UserAccount(
			//		//	"jbownen", "1234", AccountType.StandardUser, "Jack", "Bowen", "Routing Specialist"));
			//		//var j2 = APL.I.AddUserAccount(new UserAccount(
			//		//	"jb3wnen", "1234", AccountType.StandardUser, "Jack", "Bowen", "Routing Specialist"));
			//		//var j4 = APL.I.AddUserAccount(new UserAccount(
			//		//	"jbwnen", "1234", AccountType.StandardUser, "Jack", "Bowen", "Routing Specialist"));
			//		//var j5 = APL.I.AddUserAccount(new UserAccount(
			//		//	"jbownen", "1234", AccountType.StandardUser, "Jack", "Bowen", "Routing Specialist"));
			//		//var j6 = APL.I.AddUserAccount(new UserAccount(
			//		//	"jbownen", "1234", AccountType.StandardUser, "Jack", "Bowen", "Routing Specialist"));
			//		//var j7 = APL.I.AddUserAccount(new UserAccount(
			//		//	"jbownen", "1234", AccountType.StandardUser, "Jack", "Bowen", "Routing Specialist"));

			//		//BindingExpression
			//		//APLOLD.I.AddAccount("johncoleman", "1234", AccountType.StandardUser, "John", "Coleman", "Standard User");
			//		//APLOLD.I.AddAccount("tomcollins", "1234", AccountType.StandardUser, "Tom", "Collins", "Standard User");
			//		//APLOLD.I.AddAccount("raymondmorris", "1234", AccountType.StandardUser, "Raymond", "Morris", "Standard User");
			//		//APLOLD.I.AddAccount("chriscook", "1234", AccountType.StandardUser, "Chris", "Cook", "Standard User");
			//		//APLOLD.I.AddAccount("timwhite", "1234", AccountType.Manager, "Tim", "White", "Manager");
			//		//var account = APLOLD.I.GetUser("frunkis");

			//		//var jobAssignmentGroup = APL.I.AddJobAssignmentGroup(account);

			//		//var charlotte = APL.I.GetCity("Charlotte");

			//		//jobAssignmentGroup.JobAssignments.Add(new JobAssignment
			//		//{
			//		//	AssociatedCityID = charlotte.CityID,
			//		//	Deadline = new DateTime(2016, 11, 30, 20, 0, 0),
			//		//	CurrentDailyTeamCount = 6,
			//		//	FlexTeams = 1,
			//		//	HasStores = true,
			//		//	IsAutoInput = false
			//		//});
			//		//APL.I.test();

			//		//importStores();
			//	}

			//private static readonly string storesCSVPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
			//																		 + @"\UST Routing\StoresExport.csv";

			//private void addStores()
			//{
			//	APLOLD.I.AddCity("Houston", "Houston.jpg", 001, "HOU");
			//	APLOLD.I.AddCity("Beaumont", "Beaumont.jpg", 003, "BEU");
			//	APLOLD.I.AddCity("Lafayette", "Lafayette.jpg", 022, "LAF");
			//	APLOLD.I.AddCity("Austin", "Austin.jpg", 063, "AUS");
			//	APLOLD.I.AddCity("Oklahoma City", "Oklahoma City.jpg", 113, "OKC");
			//	APLOLD.I.AddCity("El Paso", "El Paso.jpg", 124, "ELP");
			//	APLOLD.I.AddCity("Tuscon", "Tuscon.jpg", 125, "TUC");
			//	APLOLD.I.AddCity("Pheonix", "Pheonix.jpg", 132, "ALBQ");
			//	APLOLD.I.AddCity("Tulsa", "Tulsa.jpg", 133, "TUL");
			//	APLOLD.I.AddCity("Amarillo", "Amarillo.jpg", 146, "AMA");
			//	APLOLD.I.AddCity("Charlotte", "Charlotte.jpg", 150, "CHA");
			//	APLOLD.I.AddCity("Laredo", "Laredo.jpg", 152, "LAR");
			//	APLOLD.I.AddCity("Shreveport", "Shreveport.jpg", 156, "TUL");
			//	APLOLD.I.AddCity("Memphis", "Memphis.jpg", 165, "MEM");
			//	APLOLD.I.AddCity("Jackson", "Jackson.jpg", 166, "JAC");
			//	APLOLD.I.AddCity("Corpus Christi", "Corpus Christi.jpg", 167, "CORP");
			//	APLOLD.I.AddCity("Odessa", "Odessa.jpg", 168, "ODE");
			//	APLOLD.I.AddCity("Lubbock", "Lubbock.jpg", 169, "LUB");
			//	APLOLD.I.AddCity("Knoxville", "Knoxville.jpg", 171, "KNOX");
			//	APLOLD.I.AddCity("Florence", "Florence.jpg", 172, "FLO");
			//	APLOLD.I.AddCity("Greenville", "Greenville.jpg", 178, "GRNV");
			//	APLOLD.I.AddCity("McAllen", "McAllen.jpg", 179, "MCA");
			//	APLOLD.I.AddCity("Waco", "Waco.jpg", 207, "WACO");
			//	APLOLD.I.AddCity("Baton Rouge", "Baton Rouge.jpg", 209, "BATR");
			//	APLOLD.I.AddCity("Nashville", "Nashville.jpg", 215, "NASH");
			//	APLOLD.I.AddCity("Chattanooga", "Chattanooga.jpg", 220, "CHAT");
			//	APLOLD.I.AddCity("Raliegh", "Raliegh.jpg", 230, "RAL");
			//	APLOLD.I.AddCity("San Antonio", "San Antonio.jpg", 260, "SANA");
			//	APLOLD.I.AddCity("Albuquerque", "Albuquerque.jpg", -1, "", "NM", inferred: true);
			//	APLOLD.I.AddCity("Alexandria", "Alexandria.jpg", -1, "", "LA", inferred: true);
			//	APLOLD.I.AddCity("Antioch", "Antioch.jpg", -1, "", "TN", inferred: true);
			//	APLOLD.I.AddCity("Arlington", "Arlington.jpg", -1, "", "TX", inferred: true);
			//	APLOLD.I.AddCity("Augusta", "Augusta.jpg", -1, "", "GA", inferred: true);
			//	APLOLD.I.AddCity("Baytown", "Baytown.jpg", -1, "", "TX", inferred: true);
			//	APLOLD.I.AddCity("Beaumont", "Beaumont.jpg", -1, "", "TX", inferred: true);
			//	APLOLD.I.AddCity("Beaumont", "Beaumont.jpg", -1, "", "TX", inferred: true);
			//	City city;
			//	APLOLD.I.TryAddCity("Brownsville", "Brownsville.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Burleston", "Burleston.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Cedar Hill", "Cedar Hill.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Chandler", "Chandler.jpg", -1, "", out city, "AZ", inferred: true);
			//	APLOLD.I.TryAddCity("Conroe", "Conroe.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Dallas", "Dallas.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Fayetteville", "Fayetteville.jpg", -1, "", out city, "NC", inferred: true);
			//	APLOLD.I.TryAddCity("Fort Worth", "Fort Worth.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Gastonia", "Gastonia.jpg", -1, "", out city, "NC", inferred: true);
			//	APLOLD.I.TryAddCity("Goodyear", "Goodyear.jpg", -1, "", out city, "AZ", inferred: true);
			//	APLOLD.I.TryAddCity("Greensboro", "Greensboro.jpg", -1, "", out city, "NC", inferred: true);
			//	APLOLD.I.TryAddCity("Harlingen", "Harlingen.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Hickory", "Hickory.jpg", -1, "", out city, "NC", inferred: true);
			//	APLOLD.I.TryAddCity("Humble", "Humble.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Huntsville", "Huntsville.jpg", -1, "", out city, "AL", inferred: true);
			//	APLOLD.I.TryAddCity("Hurst", "Hurst.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Katy", "Katy.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Lake Charles", "Lake Charles.jpg", -1, "", out city, "LA", inferred: true);
			//	APLOLD.I.TryAddCity("Lake Worth", "Lake Worth.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Las Cruces", "Las Cruces.jpg", -1, "", out city, "NM", inferred: true);
			//	APLOLD.I.TryAddCity("Lewisville", "Lewisville.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Lufkin", "Lufkin.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Madison", "Madison.jpg", -1, "", out city, "TN", inferred: true);
			//	APLOLD.I.TryAddCity("Mesa", "Mesa.jpg", -1, "", out city, "AZ", inferred: true);
			//	APLOLD.I.TryAddCity("Mesquite", "Mesquite.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Monroe", "Monroe.jpg", -1, "", out city, "LA", inferred: true);
			//	APLOLD.I.TryAddCity("New Liberia", "New Liberia.jpg", -1, "", out city, "LA", inferred: true);
			//	APLOLD.I.TryAddCity("North Charleston", "North Charleston.jpg", -1, "", out city, "SC", inferred: true);
			//	APLOLD.I.TryAddCity("Orange", "Orange.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Pasadena", "Pasadena.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Pearland", "Pearland.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Plano", "Plano.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Port Arthur", "Port Arthur.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Scottsdale", "Scottsdale.jpg", -1, "", out city, "AZ", inferred: true);
			//	APLOLD.I.TryAddCity("Southhaven", "Southhaven.jpg", -1, "", out city, "MS", inferred: true);
			//	APLOLD.I.TryAddCity("Spartanburg", "Spartanburg.jpg", -1, "", out city, "SC", inferred: true);
			//	APLOLD.I.TryAddCity("Spring", "Spring.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Sugarland", "Sugarland.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Tempe", "Tempe.jpg", -1, "", out city, "AZ", inferred: true);
			//	APLOLD.I.TryAddCity("Webster", "Webster.jpg", -1, "", out city, "TX", inferred: true);
			//	APLOLD.I.TryAddCity("Winston-Salem", "Winston-Salem.jpg", -1, "", out city, "NC", inferred: true);
			//	APLOLD.I.TryAddCity("Yuma", "Yuma.jpg", -1, "", out city, "AZ", inferred: true);

			//}
			//private void importStores()
			//{
			//	APLOLD.I.DeleteAllStores();
			//	using (var fileReader = new StreamReader(storesCSVPath))
			//	{
			//		var line = fileReader.ReadLine();
			//		while ((line = fileReader.ReadLine()) != null)
			//		{
			//			var storeExcelRecord = StoreDataReader.ParseStoreEntryFromCSV(line);
			//			var store = APLOLD.I.AddStore(storeExcelRecord);
			//			//storeExcelRecord.LegacyStoreID, 
			//			//storeExcelRecord.AssociatedCityID)
			//			//foreach (var guestEntry in excelRecord.PanelGuestNames)
			//			//{
			//			//	if (guestEntry.IsNullOrEmpty())
			//			//	{

			//			//	}
			//			//	if (guestEntry == "?")
			//			//	{
			//			//		APL.I.InsertGuestIfDistinct("Unknown Guest");
			//			//	}
			//			//	else if (guestEntry == "Doctor Dr")
			//			//	{
			//			//		APL.I.InsertGuestIfDistinct("Doctor Dré");
			//			//	}
			//			//	else
			//			//	{
			//			//		APL.I.InsertGuestIfDistinct(guestEntry);
			//			//	}
			//		}
			//	}

			//}
		}
}