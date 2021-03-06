﻿using System.Data.Entity;

namespace DBProvider
{
	public static class EF_FIX
	{
		public static void FixEfProviderServicesProblem()
		{
			//The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
			//for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
			//Make sure the provider assembly is available to the running application. 
			//See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

			var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
		}
	}

	public partial class DB : DbContext
	{
		public DB() : base("name=DB")
		{
			EF_FIX.FixEfProviderServicesProblem();
		}
	}
}
