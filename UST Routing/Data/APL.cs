using System;
using System.ComponentModel;
using System.Linq;
using Core.Controls;
using Core.Data;
using Core.Extensions;
using Core.Helpers.CLREventHelpers;
using JetBrains.Annotations;
using UST_Routing.Accounts;

namespace UST_Routing.Data
{
	public partial class APL : ObservableObject
	{
		#region Singleton

		protected static APL instance;
		public static APL I
		{
			get
			{
				if (instance == null)
				{
					instance = new APL();
					instance.OnCreated();
				}
				return instance;
			}
		}

		public void OnCreated()
		{
		}

		#endregion


		protected USTDataContext ctx
		{
			get
			{
				return new USTDataContext();
			}
		}

	

	}
}