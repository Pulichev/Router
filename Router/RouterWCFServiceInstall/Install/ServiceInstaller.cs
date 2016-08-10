using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace  Web.Router.Service {
 
    [RunInstaller(true)]
	public class ServiceInstaller : Installer
	{

	    public ServiceInstaller() {
	        var processInstaller = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};

	        var serviceInstaller = new System.ServiceProcess.ServiceInstaller {
	            ServiceName = "TNS.RouterService",
	            DisplayName = "TNS.RouterService: сервис для интерфейса Router",
	            StartType = ServiceStartMode.Automatic,
	            Description = "Работа с БД интерфеса Router"
	        };

	        Installers.AddRange(new Installer[] {processInstaller, serviceInstaller});
	    }
	}
}
