using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Web.Router.WCF;

//Попытка создать службу windows. Успехом не увенчалась. Пришлось хостить в IIS

namespace Web.Router.Service {
    
    public class RouterService : ServiceBase
	{
		public ServiceHost serviceHost = null;
		public RouterService()
		{
			// Name the Windows Service
			ServiceName = "Router WCF Service";
		}
		

		// Start the Windows service.
		protected override void OnStart(string[] args)
		{
            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(RouterWCF));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
		}

		protected override void OnStop()
		{
			if (serviceHost != null)
			{
				serviceHost.Close();
				serviceHost = null;
			}
		}
	}
}
