using System.Collections.Generic;
using Data;

namespace Core
{
	public interface IRepository
	{
		IEnumerable<Super> SuperList(int place, int placeType, int workType, int state);
		IEnumerable<Manager> ManagerList(int superId);
		IEnumerable<Place> PlaceList();
		IEnumerable<WorkType> WorkTypeList();
		IEnumerable<State> StateList();
		List<Agreement> AgreeTypeList();

		SuperDetails SuperDetailsElement(int superId);
		void ManagerAdd(Manager manager);
		void SuperDetailsAdd(SuperDetails super);
		void ManagerDelete(int managerId);
		void SuperDelete(int superId);
		void ManagerUpdate(Manager manager);
		void SuperUpdate(SuperDetails super);
	}
}
