using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using UST_Routing.ViewModels;

namespace UST_Routing
{
	public class AppBootstrapper : BootstrapperBase
	{
		public AppBootstrapper()
		{
			Initialize();
		}

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			var settings = new Dictionary<string, object>
			{
				{ "SizeToContent", SizeToContent.Manual },
				{ "WindowState" , WindowState.Maximized }
			};

			DisplayRootViewFor<AppRootViewModel>(settings);
			//NotificationsService.I.InitializeNotificationHost();
		}
	}
}