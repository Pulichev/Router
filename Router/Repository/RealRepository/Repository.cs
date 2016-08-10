using System.Collections.Generic;
using Data;
using Core;
using DBProvider;

namespace RealRepository
{
	public class Repository : IRepository
	{
		private readonly OldDbProvider _dbProvider = new OldDbProvider();

		public List<Agreement> AgreeTypeList()
		{
			return _dbProvider.AgreeTypeList();
		}

		public SuperDetails SuperDetailsElement(int superId)
		{
			return _dbProvider.SuperDetailsElement(superId);
		}

		public IEnumerable<Manager> ManagerList(int superId)
		{
			return _dbProvider.ManagerList(superId);
		}

		public IEnumerable<Place> PlaceList()
		{
			return _dbProvider.PlaceList();
		}

		public IEnumerable<WorkType> WorkTypeList()
		{
			return _dbProvider.WorkTypeList();
		}

		public IEnumerable<State> StateList()
		{
			return _dbProvider.StateList();
		}

		public IEnumerable<Super> SuperList(int place, int placeType, int workType, int state)
		{
			return _dbProvider.SuperList(place, placeType, workType, state);
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
