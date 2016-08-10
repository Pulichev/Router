using System.Collections.Generic;
using System.ServiceModel;
using Data;

namespace Web.Router.WCF
{
	[ServiceContract]

	public interface IRouterWCF
	{
		[OperationContract]
		string UserName();

		[OperationContract]
		SuperDetails SuperDetailsElement(int superId);

		[OperationContract]
		List<Manager> ManagerList(int superId);
        
        [OperationContract]
		List<Place> PlaceList();

		[OperationContract]
		List<WorkType> WorkTypeList();

		[OperationContract]
		List<State> StateList();

		[OperationContract]
		List<Agreement> AgreeTypeList();

		[OperationContract]
		List<Super> SuperList(int place, int placeType, int workType, int state);

		[OperationContract]
		void ManagerAdd(Manager manager);

		[OperationContract]
		void SuperDetailsAdd(SuperDetails s);

		[OperationContract]
		void ManagerDelete(int managerId);

		[OperationContract]
		void SuperDelete(int superId);

		[OperationContract]
		void ManagerUpdate(Manager manager);

		[OperationContract]
		void SuperUpdate(SuperDetails super);
	}
}