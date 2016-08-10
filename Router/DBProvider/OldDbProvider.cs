using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace DBProvider
{
	public class OldDbProvider
	{
		private List<Works> WorksFilling(ICollection<super_works> works)
		{
			var worksList = new List<Works>();
			foreach (var wtId in works)
				worksList.Add(new Works { WorkId = wtId.super_work_id, WorkTypeId = wtId.super_work_type_id });
			return worksList;
		}

		private int StateGet(ICollection<super_properties> properties)
		{
			var stateId = 0;
			foreach (var propertie in properties)
				stateId = propertie.super_state_id;
			return stateId;
		}

		private Place PlaceGet(ICollection<super_places> places)
		{
			var placeEl = new Place();
			foreach (var place in places)
			{
				if (place.super_territory_type_id == 1)
				{
					placeEl.Id = place.territory_id;
					placeEl.Type = place.super_place_type_id;
					placeEl.SuperPlacesId = place.super_place_id;
				}
			}
			return placeEl;
		}

		private List<Place> PlaceFilling(ICollection<super_places> places, int territoryType)
		{
			List<Place> placesEl = new List<Place>();
			foreach (var place in places)
			{
				if (place.super_territory_type_id == territoryType)
					placesEl.Add(new Place { SuperPlacesId = place.super_place_id, Id = place.territory_id, Type = place.super_place_type_id });
			}
			return placesEl;
		}

		private List<Agreement> AgreementsFilling(ICollection<super_agreements> agreements)
		{
			List<Agreement> agreementsEl = new List<Agreement>();
			foreach (var agree in agreements)
			{
				using (var _db = new MICRouterEntities())
				{
					var query = from agreement in _db.super_agree_types
								where agreement.super_agree_type_id == agree.super_agree_type_id
						select agreement.agree_name;
					agreementsEl.Add(new Agreement
					{
						AgreeId = agree.super_agree_id,
						AgreeTypeId = agree.super_agree_type_id,
						AgreeName = query.FirstOrDefault()
					});
				}
			}
			return agreementsEl;
		}

		//ACTIONS.
		public SuperDetails SuperDetailsElement(int superId)
		{
			using (var _db = new MICRouterEntities())
			{
				var items = new List<SuperDetails>();
				var query1 = from super in _db.supervisors
							 orderby super.supervisor_id
							 where super.supervisor_id == superId
							 select super;
				foreach (var super in query1)
				{
					items.Add(new SuperDetails
					{
						Id = super.supervisor_id,
						NameFact = super.name_fact,
						NameLaw = super.name_law,
						HeadName = super.head_name,
						HeadComment = super.head_comment,
						HeadPhoneWork = super.head_phone_work,
						HeadPhoneHome = super.head_phone_home,
						HeadPhoneMobile = super.head_phone_mobile,
						Fax = super.fax,
						Http = super.http,
						HeadEmail = super.head_email,
						FieldName = super.field_name,
						FieldComment = super.field_comment,
						FieldPhoneWork = super.field_phone_work,
						FieldPhoneHome = super.field_phone_home,
						FieldPhoneMobile = super.field_phone_mobile,
						FieldEmail = super.field_email,
						InterCount = Convert.ToInt32(super.inter_count),
						AddressFact = super.address_fact,
						AddressLaw = super.address_law,
						ComputerCount = Convert.ToInt32(super.computer_count),
						ManagerCount = Convert.ToInt32(super.manager_count),
						INN = super.INN,
						KPP = super.KPP,
						VAT = Convert.ToBoolean(super.VAT),
						VAT_Argument = super.VAT_argument,
						Recvisits = super.recvisits,
						Description = super.description,
						FinHead = super.fin_head,
						FinPosition = super.fin_position,
						WorkOn = super.work_on,
						IndLicense = super.ind_licence,
						IndTax = super.ind_tax,
						IndInn = super.ind_inn,
						IndRegister = super.ind_register,
						DescControl = super.desc_control,
						Login = super.login,
						Password = super.password,
						Folder = super.folder,
						Dictaphone = Convert.ToInt32(super.dictaphone),
						Notebook = Convert.ToInt32(super.notebook),
						Computer = Convert.ToInt32(super.computer),
						Pda = Convert.ToInt32(super.pda),
						PlaceId = PlaceGet(super.super_places),
						StateId = StateGet(super.super_properties),
						Works = WorksFilling(super.super_works),
						Brigades = PlaceFilling(super.super_places, 2),
						Leave = PlaceFilling(super.super_places, 3),
						Agreements = AgreementsFilling(super.super_agreements)
					});
				}
				return items[0];
			}
		}

		public List<Manager> ManagerList(int superId)
		{
			using (var _db = new MICRouterEntities())
			{
				var items = new List<Manager>();
				var query = from manager in _db.super_manager_v
							orderby manager.id
							where manager.supervisor_id == superId
							select manager;
				foreach (var manager in query)
				{
					items.Add(new Manager
					{
						Id = manager.id,
						FIO = manager.name,
						Telephone = manager.phone,
						Mail = manager.email,
						Commentary = manager.desc,
						SuperId = manager.supervisor_id
					});
				}
				return items;
			}
		}

		public List<Place> PlaceList()
		{
			using (var _db = new MICRouterEntities())
			{
				var placeList = _db.place_list.Select(x => new Place
				{
					Id = x.place_id,
					Type = x.place_type,
					Name = x.name,
					Region = x.region_name
				});
				placeList = placeList.OrderBy(x => x.Name);
				return placeList.ToList();
			}
		}

		public List<Agreement> AgreeTypeList()
		{
			using (var _db = new MICRouterEntities())
			{
				var AgreeTypeList = _db.super_agree_types.Select(x => new Agreement
				{
					AgreeTypeId = x.super_agree_type_id,
					AgreeName = x.agree_name
				});
				AgreeTypeList = AgreeTypeList.OrderBy(x => x.AgreeName);
				return AgreeTypeList.ToList();
			}
		}

		public List<WorkType> WorkTypeList()
		{
			using (var _db = new MICRouterEntities())
			{
				return _db.super_work_type_list_v.Select(x => new WorkType
				{
					Id = x.id,
					Name = x.name
				}).ToList();
			}
		}

		public List<State> StateList()
		{
			using (var _db = new MICRouterEntities())
			{
				return _db.super_state_list_v.Select(x => new State
				{
					Id = x.id,
					Name = x.name
				}).ToList();
			}
		}

		public List<Super> SuperList(int place, int placeType, int workType, int state)
		{
			var items = new List<Super>();
			using (var _db = new MICRouterEntities())
			{
				var query = _db.router_super_list(Convert.ToByte(placeType), place, Convert.ToByte(state),
					Convert.ToByte(workType));
				foreach (var super in query)
				{
					items.Add(new Super()
					{
						Id = super.supervisor_id,
						Location = (new Place { Name = super.place, Region = super.region }).FullPlaceName,
						TerritoryType = super.territory_type,
						Company = super.name_fact,
						Head = super.head_name,
						Phone = super.head_phone_work,
						EMail = super.head_email,
						State = super.super_state
					});
				}
				items = items.OrderBy(x => x.Id).ToList();
			}
			return items;
		}

		public void ManagerAdd(Manager manager)
		{
			using (var _db = new MICRouterEntities())
			{
				_db.router_manager_add(manager.SuperId, manager.FIO, manager.Telephone, manager.Mail, manager.Commentary);
			}
		}

		public void SuperDetailsAdd(SuperDetails s)
		{
			using (var _db = new MICRouterEntities())
			{
				var addedSuperId = _db.router_supervisor_add(s.NameFact, Convert.ToByte(s.StateId), s.NameLaw,
					s.HeadName, s.HeadComment, s.HeadPhoneWork, s.HeadPhoneHome, s.HeadPhoneMobile,
					s.Fax, s.Http, s.HeadEmail, s.FieldName, s.FieldComment, s.FieldPhoneWork, s.FieldPhoneHome,
					s.FieldPhoneMobile, s.FieldEmail, Convert.ToInt16(s.InterCount), s.AddressFact, s.AddressLaw,
					Convert.ToInt16(s.ComputerCount),
					Convert.ToInt16(s.ManagerCount), s.INN, s.KPP, s.VAT, s.VAT_Argument, s.Recvisits, s.Description,
					s.FinHead, s.FinPosition,
					s.WorkOn, s.IndLicense, s.IndTax, s.IndInn, s.IndRegister, s.DescControl, s.Login, s.Password, s.Folder, s.Dictaphone,
					s.Notebook, s.Computer, s.Pda).FirstOrDefault();
				_db.router_supervisor_place_add(addedSuperId, s.PlaceId.Id, 1, Convert.ToByte(s.PlaceId.Type));
				foreach (var place in s.Leave)
					_db.router_supervisor_place_add(addedSuperId, place.Id, 3, Convert.ToByte(place.Type));
				foreach (var place in s.Brigades)
					_db.router_supervisor_place_add(addedSuperId, place.Id, 2, Convert.ToByte(place.Type));
				foreach (var work in s.Works)
					_db.router_supervisor_work_add(addedSuperId, Convert.ToByte(work.WorkTypeId));
				foreach (var agree in s.Agreements)
					_db.router_supervisor_agreement_add(addedSuperId, Convert.ToByte(agree.AgreeTypeId));
			}
		}

		public void ManagerDelete(int managerId)
		{
			using (var _db = new MICRouterEntities())
			{
				_db.router_manager_delete(managerId);
			}
		}

		public void SuperDelete(int superId)
		{ 
			using (var _db = new MICRouterEntities())
			{
				var willBeDeleted = SuperDetailsElement(superId);
				_db.router_supervisor_place_delete(willBeDeleted.PlaceId.SuperPlacesId);
				foreach (var place in willBeDeleted.Leave)
					_db.router_supervisor_place_delete(place.SuperPlacesId);
				foreach (var place in willBeDeleted.Brigades)
					_db.router_supervisor_place_delete(place.SuperPlacesId);
				foreach (var work in willBeDeleted.Works)
					_db.router_supervisor_work_del(work.WorkId);
				_db.router_supervisor_delete(superId);
			}
		}

		public void ManagerUpdate(Manager manager)
		{
			using (var _db = new MICRouterEntities())
			{
				_db.router_manager_update(manager.Id, manager.SuperId, manager.FIO,
					manager.Telephone, manager.Mail, manager.Commentary);
			}
		}

		public void SuperUpdate(SuperDetails super)
		{
			using (var _db = new MICRouterEntities())
			{
				SuperDetails oldSuperDetails = SuperDetailsElement(super.Id);
				//Сверяем старые значения с новыми для Works, Places
				if (oldSuperDetails.PlaceId.Id != super.PlaceId.Id)
					_db.router_supervisor_place_update(oldSuperDetails.PlaceId.SuperPlacesId, oldSuperDetails.Id,
						super.PlaceId.Id, super.PlaceId.Type, 1);

				//Сначала смотрим, что нужно удалить из уже существующих записей. Города, с которых "была снята галка".
				foreach (var brigadesOld in oldSuperDetails.Brigades)
				{
					var isContented = false;
					foreach (var brigadesNew in super.Brigades)
						if (brigadesOld.Id == brigadesNew.Id)
							isContented = true;
					if (!isContented)
						_db.router_supervisor_place_delete(brigadesOld.SuperPlacesId);
				}
				//Теперь смотрим, что нужно добавить. Тоже самое будет с Leaves и пр.
				foreach (var brigadesNew in super.Brigades)
				{
					var isContented = false;
					foreach (var brigadesOld in oldSuperDetails.Brigades)
						if (brigadesOld.Id == brigadesNew.Id)
							isContented = true;
					if (!isContented)
						_db.router_supervisor_place_add(super.Id, brigadesNew.Id, 2, Convert.ToByte(brigadesNew.Type));
				}

				foreach (var leavesOld in oldSuperDetails.Leave)
				{
					var isContented = false;
					foreach (var leavesNew in super.Leave)
						if (leavesOld.Id == leavesNew.Id)
							isContented = true;
					if (!isContented)
						_db.router_supervisor_place_delete(leavesOld.SuperPlacesId);
				}

				foreach (var leavesNew in super.Leave)
				{
					var isContented = false;
					foreach (var leavesOld in oldSuperDetails.Leave)
						if (leavesOld.Id == leavesNew.Id)
							isContented = true;
					if (!isContented)
						_db.router_supervisor_place_add(super.Id, leavesNew.Id, 3, Convert.ToByte(leavesNew.Type));
				}

				foreach (var workOld in oldSuperDetails.Works)
				{
					var isContented = false;
					foreach (var workNew in super.Works)
						if (workOld.WorkTypeId == workNew.WorkTypeId)
							isContented = true;
					if (!isContented)
						_db.router_supervisor_work_del(workOld.WorkId);
				}

				foreach (var workNew in super.Works)
				{
					var isContented = false;
					foreach (var workOld in oldSuperDetails.Works)
						if (workOld.WorkTypeId == workNew.WorkTypeId)
							isContented = true;
					if (!isContented)
						_db.router_supervisor_work_add(super.Id, Convert.ToByte(workNew.WorkTypeId));
				}

				foreach (var agreeOld in oldSuperDetails.Agreements)
				{
					var isContented = false;
					foreach (var agreeNew in super.Agreements)
						if (agreeOld.AgreeTypeId == agreeNew.AgreeTypeId)
							isContented = true;
					if (!isContented)
						_db.router_supervisor_agreement_del(agreeOld.AgreeId);
				}

				foreach (var agreeNew in super.Agreements)
				{
					var isContented = false;
					foreach (var agreeOld in oldSuperDetails.Agreements)
						if (agreeOld.AgreeTypeId == agreeNew.AgreeTypeId)
							isContented = true;
					if (!isContented)
						_db.router_supervisor_agreement_add(super.Id, Convert.ToByte(agreeNew.AgreeTypeId));
				}

				_db.router_supervisor_update(super.Id, super.NameFact, Convert.ToByte(super.StateId), super.NameLaw,
					super.HeadName, super.HeadComment, super.HeadPhoneWork, super.HeadPhoneHome, super.HeadPhoneMobile,
					super.Fax, super.Http, super.HeadEmail, super.FieldName, super.FieldComment, super.FieldPhoneWork,
					super.FieldPhoneHome,
					super.FieldPhoneMobile, super.FieldEmail, Convert.ToInt16(super.InterCount), super.AddressFact,
					super.AddressLaw,
					Convert.ToInt16(super.ComputerCount), Convert.ToInt16(super.ManagerCount), super.INN, super.KPP,
					super.VAT, super.VAT_Argument,
					super.Recvisits, super.Description, super.FinHead, super.FinPosition, super.WorkOn, super.IndLicense,
					super.IndTax, super.IndInn, super.IndRegister,
					super.DescControl, super.Login, super.Password, super.Folder, super.Dictaphone, super.Notebook, super.Computer, super.Pda);
			}
		}
	}
}
