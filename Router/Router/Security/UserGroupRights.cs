using System;
using System.Security.Principal;
using System.Threading;

namespace Router.Security
{
	public class UserGroupRights
	{
		public bool IsRoleFounded = false;
		public bool IsExportToExcelEnabled;
		public bool IsEditEnabled;
		public bool IsLogPasVisabilityEnabled;
		public bool IsAgreementsVisible;

		public UserGroupRights()
		{
			AppDomain myDomain = Thread.GetDomain();
			myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			WindowsPrincipal principle = (WindowsPrincipal) Thread.CurrentPrincipal;
			string[] roles = {"RouterAdmins", "RouterEditors", "RouterExporter", "RouterViewers"};
			//foreach (var role in roles)
			//	if (principle.IsInRole(role))
			//	{
            string role = "RouterAdmins";
					IsRoleFounded = true;
					switch (role)
					{
						case "RouterViewers":
							RouterViewers();
							break;
						case "RouterEditors":
							RouterEditors();
							break;
						case "RouterExporter":
							RouterExporter();
							break;
						case "RouterAdmins":
							RouterAdmins();
							break;
					}
			//		break;
			//	}
		}

		public void RouterViewers()
		{
			IsExportToExcelEnabled = false;
			IsEditEnabled = false;
			IsLogPasVisabilityEnabled = false;
			IsAgreementsVisible = false;
		}

		public void RouterEditors()
		{
			IsExportToExcelEnabled = false;
			IsEditEnabled = true;
			IsLogPasVisabilityEnabled = false;
			IsAgreementsVisible = true;
		}

		public void RouterExporter()
		{
			IsExportToExcelEnabled = true;
			IsEditEnabled = false;
			IsLogPasVisabilityEnabled = false;
			IsAgreementsVisible = false;
		}

		public void RouterAdmins()
		{
			IsExportToExcelEnabled = true;
			IsEditEnabled = true;
			IsLogPasVisabilityEnabled = true;
			IsAgreementsVisible = true;
		}
	}
}
