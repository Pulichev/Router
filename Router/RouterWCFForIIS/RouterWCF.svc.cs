using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
using DBProvider;

namespace Web.Router.WCF
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
//	[ServiceBehaviorAttribute]
	public class RouterWCF : IRouterWCF
	{
		private readonly OldDbProvider _dbProvider = new OldDbProvider();

		public SuperDetails SuperDetailsElement(int superId)
		{
			return _dbProvider.SuperDetailsElement(superId);
		}

		public List<Manager> ManagerList(int superId)
		{
			return _dbProvider.ManagerList(superId).ToList();
		}

		public List<Place> PlaceList()
		{
			return _dbProvider.PlaceList().ToList();
		}

		public List<WorkType> WorkTypeList()
		{
			return _dbProvider.WorkTypeList().ToList();
		}

		public List<State> StateList()
		{
			return _dbProvider.StateList().ToList();
		}

		public List<Super> SuperList(int place, int placeType, int workType, int state)
		{
			return _dbProvider.SuperList(place, placeType, workType, state).ToList();
		}

		public void ManagerAdd(Manager manager)
		{
			_dbProvider.ManagerAdd(manager);
		}

		public void SuperDetailsAdd(SuperDetails s)
		{
			_dbProvider.SuperDetailsAdd(s);
		}

		public void ManagerDelete(int managerId)
		{
			_dbProvider.ManagerDelete(managerId);
		}

		public void SuperDelete(int superId)
		{
			_dbProvider.SuperDelete(superId);
		}

		public void ManagerUpdate(Manager manager)
		{
			_dbProvider.ManagerUpdate(manager);
		}

		public void SuperUpdate(SuperDetails super)
		{
			_dbProvider.SuperUpdate(super);
		}
	}
}
