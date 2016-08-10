using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
//using DBProvider;

namespace Web.Router.WCF
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
	[ServiceContract]

	public interface IRouterWCF
	{
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