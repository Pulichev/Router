using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data;
using System.ComponentModel;
using System.Linq;
using Router.Security;

namespace Router.Model
{
	public class SuperDetailsModel : PropertyChangeEventBase, IDataErrorInfo
	{
		private UserGroupRights _userRights;

		public SuperDetailsModel(UserGroupRights userRights, SuperDetails item, IEnumerable<State> states,
			IEnumerable<WorkType> workTypes, IEnumerable<Place> placeElement, List<Agreement> agreeTypesList)
		{
			_userRights = userRights;
			_places = placeElement.Where(x => x.Id != 0); //
			_states = states.Where(x => x.Id != 0);       //Удаляем "Любой" из наших списков
			_workTypes = workTypes.Where(x => x.Id != 0); //
			_agreeTypes = agreeTypesList;
			_item = item;


			ListsFilling();
			SetSelectedPlace();
			SetSelectedState();
		}

		public SuperDetails Element
		{
			get
			{
				return _item;
			}
		}

		private SuperDetails _item;
		private IEnumerable<Place> _places;
		private IEnumerable<State> _states;
		private IEnumerable<WorkType> _workTypes;
		private List<Agreement> _agreeTypes;
		private Place _selectedItemPlace = new Place();
		private State _selectedItemState = new State();
		

		private void ListsFilling()
		{
			Works.Clear();
			Brigades.Clear();
			Leave.Clear();

			WorkTypeListFilling();
			BrigadesAndLeavesListsFilling();
			AgreementsListFilling();
		}

		private void AgreementsListFilling()
		{
			foreach (var agree in _agreeTypes)
			{
				bool chk = false;
				foreach (var agreeEl in _item.Agreements)
					if (agreeEl.AgreeTypeId == agree.AgreeTypeId)
					{
						chk = true;
						break;
					}
				Agree.Add(new SuperDetailsAgreeModel(_userRights.IsEditEnabled, this, agree, chk));
			}
		}

		private void WorkTypeListFilling()
		{
			foreach (var wt in _workTypes)
			{
				bool chk = false;
				foreach (var work in _item.Works)
					if (work.WorkTypeId == wt.Id)
					{
						chk = true;
						break;
					}
				Works.Add(new SuperDetailsWorksModel(_userRights.IsEditEnabled, this, wt, chk));
			}
		}

		private void BrigadesAndLeavesListsFilling()
		{
			foreach (var p in _places)
			{
				bool chk = false;
				foreach (var brigade in _item.Brigades)
					if (brigade.Id == p.Id && brigade.Type == p.Type)
					{
						chk = true;
						break;
					}
				Brigades.Add(new SuperDetailsPlaceBrigadeModel(_userRights.IsEditEnabled, this, p, chk));
				chk = false;
				foreach (var leave in _item.Leave)
					if (leave.Id == p.Id && leave.Type == p.Type)
					{
						chk = true;
						break;
					}
				Leave.Add(new SuperDetailsPlaceLeaveModel(_userRights.IsEditEnabled, this, p, chk));
			}
		}

		private void SetSelectedPlace()
		{
			if (_item.PlaceId != null)
			{
				foreach (var p in _places)
					if (p.Id == _item.PlaceId.Id && p.Type == _item.PlaceId.Type)
						SelectedItemPlace = p;
			}
			else
			{
				_selectedItemPlace.Name = "";
				_selectedItemPlace.Region = "";
			}
		}

		private void SetSelectedState()
		{
			if(_item.StateId != null)
				foreach (var s in _states)
					if (s.Id == _item.StateId)
						SelectedItemState = s;
		}

		private bool _BookkeepingTextBoxIsEnabled = false;
		private bool _ButtonOkIsEnabled = true;

		public bool TBIsReadOnly
		{
			get
			{
				if (_userRights.IsEditEnabled)
					return false;
				else
					return true;
			}
		}

		public bool ElementsIsEnabled
		{
			get
			{
				if (_userRights.IsEditEnabled)
					return true;
				else
					return false;
			}
		}

		public bool ButtonOkIsEnabled
		{
			get
			{
				return _ButtonOkIsEnabled;
			}
			set
			{
				_ButtonOkIsEnabled = value;
				OnPropertyChanged("ButtonOkIsEnabled");
			}
		}

		public IEnumerable<Place> TablePlaces
		{
			get
			{
				return _places;
			}
		}

		public IEnumerable<State> TableStates
		{
			get
			{
				return _states;
			}
		}

		public Place SelectedItemPlace
		{
			get
			{
				return _selectedItemPlace;
			}
			set
			{
				_selectedItemPlace = value;
				_item.PlaceId = _selectedItemPlace;
				OnPropertyChanged("SelectedItemPlace");
			}
		}

		public State SelectedItemState
		{
			get
			{
				return _selectedItemState;
			}
			set
			{
				_selectedItemState = value;
				_item.StateId = _selectedItemState.Id;
				OnPropertyChanged("SelectedItemState");
			}
		}

		public int Id
		{
			get
			{
				if (_item == null)
					return 0;
				return _item.Id;
			}
			set
			{
				_item.Id = value;
				OnPropertyChanged("Id");
			}
		}

		public string NameFact
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.NameFact;
			}
			set
			{
				_item.NameFact = value;
				OnPropertyChanged("NameFact");
			}
		}

		public string AddressFact
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.AddressFact;
			}
			set
			{
				_item.AddressFact = value;
				OnPropertyChanged("AddressFact");
			}
		}

		public string Http
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.Http;
			}
			set
			{
				_item.Http = value;
				OnPropertyChanged("Http");
			}
		}

		public string HeadName
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.HeadName;
			}
			set
			{
				_item.HeadName = value;
				OnPropertyChanged("HeadName");
			}
		}

		public string HeadComment
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.HeadComment;
			}
			set
			{
				_item.HeadComment = value;
				OnPropertyChanged("HeadComment");
			}
		}

		public string HeadPhoneWork
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.HeadPhoneWork;
			}
			set
			{
				_item.HeadPhoneWork = value;
				OnPropertyChanged("HeadPhoneWork");
			}
		}

		public string HeadPhoneHome
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.HeadPhoneHome;
			}
			set
			{
				_item.HeadPhoneHome = value;
				OnPropertyChanged("HeadPhoneHome");
			}
		}

		public string HeadPhoneMobile
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.HeadPhoneMobile;
			}
			set
			{
				_item.HeadPhoneMobile = value;
				OnPropertyChanged("HeadPhoneMobile");
			}
		}

		public string HeadEmail
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.HeadEmail;
			}
			set
			{
				_item.HeadEmail = value;
				OnPropertyChanged("HeadEmail");
			}
		}

		public string Fax
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.Fax;
			}
			set
			{
				_item.Fax = value;
				OnPropertyChanged("Fax");
			}
		}

		public int Dictaphone
		{
			get
			{
				if (_item == null)
					return 0;
				return this._item.Dictaphone;
			}
			set
			{
				_item.Dictaphone = value;
				OnPropertyChanged("Dictaphone");
			}
		}

		public int Notebook
		{
			get
			{
				if (_item == null)
					return 0;
				return this._item.Notebook;
			}
			set
			{
				_item.Notebook = value;
				OnPropertyChanged("Notebook");
			}
		}

		public int Computer
		{
			get
			{
				if (_item == null)
					return 0;
				return this._item.Computer;
			}
			set
			{
				_item.Computer = value;
				OnPropertyChanged("Computer");
			}
		}

		public int Pda
		{
			get
			{
				if (_item == null)
					return 0;
				return this._item.Pda;
			}
			set
			{
				_item.Pda = value;
				OnPropertyChanged("Pda");
			}
		}

		//Field tab
		public string FieldName
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.FieldName;
			}
			set
			{
				_item.FieldName = value;
				OnPropertyChanged("FieldName");
			}
		}

		public string FieldComment
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.FieldComment;
			}
			set
			{
				_item.FieldComment = value;
				OnPropertyChanged("FieldComment");
			}
		}

		public string FieldPhoneWork
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.FieldPhoneWork;
			}
			set
			{
				_item.FieldPhoneWork = value;
				OnPropertyChanged("FieldPhoneWork");
			}
		}

		public string FieldPhoneHome
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.FieldPhoneHome;
			}
			set
			{
				_item.FieldPhoneHome = value;
				OnPropertyChanged("FieldPhoneHome");
			}
		}

		public string FieldPhoneMobile
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.FieldPhoneMobile;
			}
			set
			{
				_item.FieldPhoneMobile = value;
				OnPropertyChanged("FieldPhoneMobile");
			}
		}

		public string FieldEmail
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.FieldEmail;
			}
			set
			{
				_item.FieldEmail = value;
				OnPropertyChanged("FieldEmail");
			}
		}

		//Bookkeeping tab
		public string NameLaw
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.NameLaw;
			}
			set
			{
				_item.NameLaw = value;
				OnPropertyChanged("NameLaw");
			}
		}

		public string AddressLaw
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.AddressLaw;
			}
			set
			{
				_item.AddressLaw = value;
				OnPropertyChanged("AddressLaw");
			}
		}

		public string FinHead
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.FinHead;
			}
			set
			{
				_item.FinHead = value;
				OnPropertyChanged("FinHead");
			}
		}

		public string FinPosition
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.FinPosition;
			}
			set
			{
				_item.FinPosition = value;
				OnPropertyChanged("FinPosition");
			}
		}

		public string WorkOn
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.WorkOn;
			}
			set
			{
				_item.WorkOn = value;
				OnPropertyChanged("WorkOn");
			}
		}

		public string INN
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.INN;
			}
			set
			{
				_item.INN = value;
				OnPropertyChanged("INN");
			}
		}

		public string Login
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.Login;
			}
			set
			{
				_item.Login = value;
				OnPropertyChanged("Login");
			}
		}

		public string Password
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.Password;
			}
			set
			{
				_item.Password = value;
				OnPropertyChanged("Password");
			}
		}

		public string Folder
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.Folder;
			}
			set
			{
				_item.Folder = value;
				OnPropertyChanged("Folder");
			}
		}

		public string AdminToolsEnabled
		{
			get
			{
				if (_userRights.IsLogPasVisabilityEnabled)
					return "Visible";
				else
					return "Hidden";
			}
		}

		public string AgreementsVisible
		{
			get
			{
				if (_userRights.IsAgreementsVisible)
					return "Visible";
				else
					return "Hidden";
			}
		}

		public string KPP
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.KPP;
			}
			set
			{
				_item.KPP = value;
				OnPropertyChanged("KPP");
			}
		}

		public string Recvisits
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.Recvisits;
			}
			set
			{
				_item.Recvisits = value;
				OnPropertyChanged("Recvisits");
			}
		}

		public bool BookkeepingTextBoxIsEnabled
		{
			get
			{
				if (_item == null)
					return false;
				if (_item.VAT == true)
				{
					if (_userRights.IsEditEnabled == true)
						_BookkeepingTextBoxIsEnabled = false;
				}
				else
				{
					if (_userRights.IsEditEnabled == true)
						_BookkeepingTextBoxIsEnabled = true;
				}
				return this._BookkeepingTextBoxIsEnabled;
			}
			set
			{
				_BookkeepingTextBoxIsEnabled = value;
			}
		}

		public bool VAT
		{
			get
			{
				if (_item == null)
					return true;
				return this._item.VAT;
			}
			set
			{
				_item.VAT = value;
				OnPropertyChanged("VAT");
				OnPropertyChanged("BookkeepingTextBoxIsEnabled");
			}
		}

		public string VAT_Argument
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.VAT_Argument;
			}
			set
			{
				_item.VAT_Argument = value;
				OnPropertyChanged("VAT_Argument");
			}
		}

		public string IndRegister
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.IndRegister;
			}
			set
			{
				_item.IndRegister = value;
				OnPropertyChanged("IndRegister");
			}
		}

		public string IndTax
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.IndTax;
			}
			set
			{
				_item.IndTax = value;
				OnPropertyChanged("IndTax");
			}
		}

		public string IndLicense
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.IndLicense;
			}
			set
			{
				_item.IndLicense = value;
				OnPropertyChanged("IndLicense");
			}
		}

		public string IndInn
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.IndInn;
			}
			set
			{
				_item.IndInn = value;
				OnPropertyChanged("IndInn");
			}
		}

		//Information tab
		public int InterCount
		{
			get
			{
				if (_item == null)
					return 0;
				return this._item.InterCount;
			}
			set
			{
				_item.InterCount = value;
				OnPropertyChanged("InterCount");
			}
		}

		public int ComputerCount
		{
			get
			{
				if (_item == null)
					return 0;
				return this._item.ComputerCount;
			}
			set
			{
				_item.ComputerCount = value;
				OnPropertyChanged("ComputerCount");
			}
		}

		public int ManagerCount
		{
			get
			{
				if (_item == null)
					return 0;
				return this._item.ManagerCount;
			}
			set
			{
				_item.ManagerCount = value;
				OnPropertyChanged("ManagerCount");
			}
		}

		public string Description
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.Description;
			}
			set
			{
				_item.Description = value;
				OnPropertyChanged("Description");
			}
		}

		public string DescControl
		{
			get
			{
				if (_item == null)
					return null;
				return this._item.DescControl;
			}
			set
			{
				_item.DescControl = value;
				OnPropertyChanged("DescControl");
			}
		}

		private ObservableCollection<SuperDetailsWorksModel> _works = new ObservableCollection<SuperDetailsWorksModel>();
		private ObservableCollection<SuperDetailsPlaceModel> _brigades = new ObservableCollection<SuperDetailsPlaceModel>();
		private ObservableCollection<SuperDetailsPlaceModel> _leave = new ObservableCollection<SuperDetailsPlaceModel>();
		private ObservableCollection<SuperDetailsAgreeModel> _agree = new ObservableCollection<SuperDetailsAgreeModel>();

		public ObservableCollection<SuperDetailsAgreeModel> Agree
		{
			get
			{
				return _agree;
			}
			set
			{
				_agree = value;
				OnPropertyChanged("Agree");
			}
		}

		public void AddAgree(Agreement agree)
		{
			_item.Agreements.Add(agree);
		}

		public void RemoveAgree(Agreement agreeEl)
		{
			foreach (var agree in _item.Agreements.ToList())
				if (agree.AgreeTypeId == agreeEl.AgreeTypeId)
					_item.Agreements.Remove(agree);
		}

		public ObservableCollection<SuperDetailsWorksModel> Works
		{
			get
			{
				return _works;
			}
			set
			{
				_works = value;
				OnPropertyChanged("Works");
			}
		}

		public void AddWork(Works work)
		{
			_item.Works.Add(work);
		}

		public void RemoveWork(Works workEl)
		{
			foreach (var work in _item.Works.ToList())
				if (work.WorkTypeId == workEl.WorkTypeId)
					_item.Works.Remove(work);
		}

		public ObservableCollection<SuperDetailsPlaceModel> Brigades
		{
			get
			{
				return _brigades;
			}
			set
			{
				_brigades = value;
				OnPropertyChanged("Brigades");
			}
		}

		public void AddBrigade(Place brigadeId)
		{
			_item.Brigades.Add(brigadeId);
		}

		public void RemoveBrigade(Place brigadeId)
		{
			foreach (var brigade in _item.Brigades.ToList())
				if (brigade.Id == brigadeId.Id && brigade.Type == brigadeId.Type)
					_item.Brigades.Remove(brigade);
		}

		public ObservableCollection<SuperDetailsPlaceModel> Leave
		{
			get
			{
				return _leave;
			}
			set
			{
				_leave = value;
				OnPropertyChanged("Leave");
			}
		}

		public void AddLeave(Place leaveId)
		{
			_item.Leave.Add(leaveId);
		}

		public void RemoveLeave(Place leaveId)
		{
			foreach (var leave in _item.Leave.ToList())
				if (leave.Id == leaveId.Id && leave.Type == leaveId.Type)
					_item.Leave.Remove(leave);
		}

		private string _ErrorMessage;

		public string ErrorMessage
		{
			get
			{
				return _ErrorMessage;
			}
			set
			{
				_ErrorMessage = value;
				OnPropertyChanged("DescControl");
			}
		}

		public string Error
		{
			get { throw new NotImplementedException(); }
		}

		public string this[string columnName]
		{
			get
			{
				string msg = null;
				switch (columnName)
				{
					case "NameFact":
						if (string.IsNullOrEmpty(this.NameFact))
						{
							msg = "Не может быть пустым";
							_ErrorMessage = msg;
							OnPropertyChanged("ErrorMessage");
							_ButtonOkIsEnabled = false;
							OnPropertyChanged("ButtonOkIsEnabled");
						}
						else
						{
							_ButtonOkIsEnabled = true;
							OnPropertyChanged("ButtonOkIsEnabled");
						}
						break;

					case "SelectedItemPlace":
						if (SelectedItemPlace == null)
						//if (string.IsNullOrEmpty(this.SelectedItemPlace.FullPlaceName))
						{
							msg = "Не может быть пустым";
							_ErrorMessage = msg;
							OnPropertyChanged("ErrorMessage");
							_ButtonOkIsEnabled = false;
							OnPropertyChanged("ButtonOkIsEnabled");
						}
						else
						{
							_ButtonOkIsEnabled = true;
							OnPropertyChanged("ButtonOkIsEnabled");
						}
						break;

					case "SelectedItemState":
						if (string.IsNullOrEmpty(this.SelectedItemState.Name))
						{
							msg = "Не может быть пустым";
							_ErrorMessage = msg;
							OnPropertyChanged("ErrorMessage");
							_ButtonOkIsEnabled = false;
							OnPropertyChanged("ButtonOkIsEnabled");
						}
						else
						{
							_ButtonOkIsEnabled = true;
							OnPropertyChanged("ButtonOkIsEnabled");
						}
						break;

					default:
						throw new ArgumentException(
							"Unrecognized property: " + columnName);
				}
				return msg;
			}
		}
	}
}
