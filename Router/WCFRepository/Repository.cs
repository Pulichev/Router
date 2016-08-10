using System.Collections.Generic;
using System.Linq;
using Core;
using Data;

namespace WCFRepository
{
	public class Repository : IRepository
	{
		private WCFServiceReference.RouterWCFClient _managerServiceClient;

		public Repository()
		{
			_managerServiceClient = new WCFServiceReference.RouterWCFClient();
			System.Net.ServicePointManager.ServerCertificateValidationCallback +=
				(se, cert, chain, sslerror) =>
				{
					return true;
				};
		}
		
		public SuperDetails SuperDetailsElement(int superId)
		{
			return _managerServiceClient.SuperDetailsElement(superId);
		}
		 
		public IEnumerable<Manager> ManagerList(int superId)
		{
			return _managerServiceClient.ManagerList(superId);
		}

		public IEnumerable<Place> PlaceList()
		{
			return _managerServiceClient.PlaceList().ToList();
		}

		public IEnumerable<WorkType> WorkTypeList()
		{
			return _managerServiceClient.WorkTypeList();
		}

		public IEnumerable<State> StateList()
		{
			return _managerServiceClient.StateList();
		}

		public List<Agreement> AgreeTypeList()
		{
			return _managerServiceClient.AgreeTypeList().ToList();
		}

		public IEnumerable<Super> SuperList(int place, int placeType, int workType, int state)
		{
			return _managerServiceClient.SuperList(place, placeType, workType, state);
		}

		public void ManagerAdd(Manager manager)
		{
			_managerServiceClient.ManagerAdd(manager);
		}

		public void SuperDetailsAdd(SuperDetails s)
		{
			_managerServiceClient.SuperDetailsAdd(s);
		}

		public void ManagerDelete(int managerId)
		{
			_managerServiceClient.ManagerDelete(managerId);
		}

		public void SuperDelete(int superId)
		{
			_managerServiceClient.SuperDelete(superId);
		}

		public void ManagerUpdate(Manager manager)
		{
			_managerServiceClient.ManagerUpdate(manager);
		}

		public void SuperUpdate(SuperDetails super)
		{
			_managerServiceClient.SuperUpdate(super);
		}
	}
}
