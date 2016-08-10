using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Data;
using Router.Model;
using Router.Dialogs;
using Core;
using Router.Security;
using Router.View;

namespace Router.ViewModel
{
	public class MainWindowViewModel : PropertyChangeEventBase
	{
		private readonly IRepository _repository;
		private readonly DialogManager _createDialog;
		private int _selectedTableId;
		private UserGroupRights _userRights;

		public DelegateCommand CreateNewPartner { get; set; }
		public DelegateCommand CreateNewManager { get; set; }
		public DelegateCommand Edit { get; set; }
		public DelegateCommand Delete { get; set; }
		public DelegateCommand ApplyChanges { get; set; }
		public DelegateCommand Update { get; set; }
		public DelegateCommand ExportToExcel { get; set; }
		public DelegateCommand MouseClickOnSuper { get; set; }
		public DelegateCommand MouseClickOnManager { get; set; }

		public MainWindowViewModel(IRepository repo, DialogManager dialogManager)
		{
			_userRights = new UserGroupRights();
			if (_userRights.IsRoleFounded)
			{
				_createDialog = dialogManager;
				CreatingDelegateCommands();
				_repository = repo;
				Refresh();
			}
			else
				MessageBox.Show("Пользователь не имеет прав на доступ к программе");
		}

		private void CreatingDelegateCommands()
		{
			CreateNewPartner = new DelegateCommand(AddActionCreateNewPartner);
			CreateNewManager = new DelegateCommand(AddActionCreateNewManager);
			Edit = new DelegateCommand(AddActionEdit);
			Delete = new DelegateCommand(AddActionDelete);
			ApplyChanges = new DelegateCommand(AddActionApplyChanges);
			Update = new DelegateCommand(AddActionUpdate);
			ExportToExcel = new DelegateCommand(AddActionExportToExcel);
			MouseClickOnSuper = new DelegateCommand(MouseClickOnSuperFunction);
			MouseClickOnManager = new DelegateCommand(MouseClickOnManagerFunction);
		}

		private void AddActionExportToExcel()
		{
			_cursorType = "Wait";
			OnPropertyChanged("CursorType");
			ExportToExcel newExport = new ExportToExcel(TableElements);
			newExport.ExecuteExport();
			_cursorType = "Arrow";
			OnPropertyChanged("CursorType");
		}

		private void AddActionUpdate()
		{
			_cursorType = "Wait";
			OnPropertyChanged("CursorType");
			Refresh();
			_cursorType = "Arrow";
			OnPropertyChanged("CursorType");
		}

		private void AddActionCreateNewPartner()
		{
			var superDetails = new SuperDetails() { PlaceId = TablePlace[1]};
			var superDetailsModel = new SuperDetailsModel(_userRights, superDetails, TableState, TableWorkType, TablePlace, _repository.AgreeTypeList());
			if (_createDialog.RaiseDialog<SuperDetailsModel>("NewSuper", ref superDetailsModel))
			{
				_repository.SuperDetailsAdd(superDetailsModel.Element);
				RefreshSuper();
				int i = 0;
				foreach (var superEl in TableElements)
				{
					if (superEl.Id == superDetailsModel.Id)
						SuperSelectedIndex = i;
					i++;
				}
			}
		}

		private void AddActionCreateNewManager()
		{
			var manager = new Manager() { SuperId = _superSelected.Id};
			var managerModel = new ManagerModel(manager, _userRights);
			if (_createDialog.RaiseDialog<ManagerModel>("NewManager", ref managerModel))
			{
				_repository.ManagerAdd(managerModel.Element);
				RefreshManagers();
				int i = 0;
				foreach (var managerEl in TableManagers)
				{
					if (managerEl.Id == managerModel.Id)
						ManagerSelectedIndex = i;
					i++;
				} 
			}
		}

		private void AddActionEdit()
		{
			_cursorType = "Wait";
			OnPropertyChanged("CursorType");
			if (ManagerSelectedIndex >= 0 && _selectedTableId == 1)
				ManagerEdit();
			else
			{
				if (SuperSelectedIndex >= 0 && _selectedTableId == 0)
					SuperEdit();
			}
		}

		private void MouseClickOnSuperFunction()
		{
			_selectedTableId = 0;
			EditIsEnabled = true;
			if (_userRights.IsEditEnabled)
			{
				AddingManagerIsEnabled = true;
				DeleteIsEnabled = true;
			}
		}

		private void MouseClickOnManagerFunction()
		{
			_selectedTableId = 1;
			EditIsEnabled = true;
			AddingManagerIsEnabled = false;
			if (_userRights.IsEditEnabled)
				DeleteIsEnabled = true;
		}

		private void SuperEdit()
		{
			if (_superSelected != null)
			{
				var superDetailsModel = new SuperDetailsModel(_userRights, _repository.SuperDetailsElement(_superSelected.Id),
					TableState, TableWorkType, TablePlace, _repository.AgreeTypeList());
				_cursorType = "Arrow";
				OnPropertyChanged("CursorType");
				if (_createDialog.RaiseDialog<SuperDetailsModel>("NewSuper", ref superDetailsModel))
				{
					_repository.SuperUpdate(superDetailsModel.Element);
					var super = SuperSelected;
					RefreshSuper();
					int i = 0;
					foreach (var superEl in TableElements)
					{
						if (superEl.Id == super.Id)
							SuperSelectedIndex = i;
						i++;
					}
				}
			}
		}

		private void ManagerEdit()
		{
			if (ManagerSelected != null)
			{
				var managerModel = new ManagerModel(ManagerSelected.Element, _userRights);
				_cursorType = "Arrow";
				OnPropertyChanged("CursorType");
				if (_createDialog.RaiseDialog<ManagerModel>("NewManager", ref managerModel))
				{
					_repository.ManagerUpdate(managerModel.Element);
					var manager = ManagerSelected;
					RefreshManagers();
					int i = 0;
					foreach (var managerEl in TableManagers)
					{
						if (managerEl.Id == manager.Id)
							ManagerSelectedIndex = i;
						i++;
					}
				}
			}
		}

		private void AddActionDelete()
		{
			var deleteConfirm = new DeleteConfirmView() as Window;
			if (deleteConfirm.ShowDialog().GetValueOrDefault(false))
			{
				if (ManagerSelectedIndex >= 0 && ManagerSelected != null && _selectedTableId == 1) 
					ManagerDelete();
				else
					if (SuperSelectedIndex >= 0 && SuperSelected != null && _selectedTableId == 0)
						SuperDelete();
			}
		}

		private void SuperDelete()
		{
			if (_superSelected != null)
			{
				_repository.SuperDelete(_superSelected.Id);
				RefreshSuper();
				if((_tableElements.Count()) != 0)
					SuperSelectedIndex = 0;
			}
		}

		private void ManagerDelete()
		{
			if (_managerSelected != null)
			{
				_repository.ManagerDelete(_managerSelected.Id);
				RefreshManagers();
				if ((_tableManagers.Count()) != 0)
					ManagerSelectedIndex = 0;
			}
		}

		private void AddActionApplyChanges()
		{
			_cursorType = "Wait";
			OnPropertyChanged("CursorType");
			RefreshSuper();
			SelectingDefaultSuper();
			_cursorType = "Arrow";
			OnPropertyChanged("CursorType");
		}

		private void Refresh()
		{
			ClearingTables();
			FillingAttributes();
			RefreshSuper();
			SelectingDefaultSuper();
		}

		private void ClearingTables()
		{
			TableManagers.Clear();
			TableElements.Clear();
			TablePlace.Clear();
			TableWorkType.Clear();
			TableState.Clear();
		}

		private void FillingAttributes()
		{
			TablePlaceFilling();
			TableWorkTypeFilling();
			TableStateFilling();			
			
			//Задаем стартовые параметры
			SelectedItemPlace = TablePlace[1];
			SelectedItemWorkType = TableWorkType[0];
			SelectedItemState = TableState[0];
		}

		private void TablePlaceFilling()
		{
			TablePlace.Add(new Place() { Id = 0, Type = 0, Name = "--Любой--", Region = ""});
			foreach (var place in _repository.PlaceList())
				TablePlace.Add(place);
		}

		private void TableWorkTypeFilling()
		{
			TableWorkType.Add(new WorkType() { Id = 0, Name = "--Любой--" });
			foreach (var workType in _repository.WorkTypeList())
				TableWorkType.Add(workType);
		}

		private void TableStateFilling()
		{
			TableState.Add(new State() { Id = 0, Name = "--Любой--" });
			foreach (var state in _repository.StateList())
				TableState.Add(state);
		}

		private void SelectingDefaultSuper()
		{
			if (TableElements.Count != 0)
			{
				SuperSelectedIndex = 0;
				SuperSelected = TableElements[0];
			}
		}

		private void RefreshSuper()
		{
			TableElements.Clear();
			if (_selectedItemPlace == null)
				MessageBox.Show("Город/область не выбраны.");
			else
				foreach (var super in _repository.SuperList(_selectedItemPlace.Id, _selectedItemPlace.Type, _selectedItemWorkType.Id, _selectedItemState.Id))
					TableElements.Add(new SuperModel(super));
		}

		private void RefreshManagers()
		{
			TableManagers.Clear();
			if (_superSelected != null)
				foreach (var manager in _repository.ManagerList(_superSelected.Id))
					TableManagers.Add(new ManagerModel(manager));
		}

		private List<Place> _TablePlace = new List<Place>();
		private List<State> _TableState = new List<State>();
		private List<WorkType> _TableWorkType = new List<WorkType>();

		private Place _selectedItemPlace;
		private State _selectedItemState;
		private WorkType _selectedItemWorkType;

		private int _superSelectedIndex = 0;
		private int _managerSelectedIndex = -1;
		private bool _editIsEnabled;
		private bool _addingManagerIsEnabled;
		private bool _deleteIsEnabled;

		private ManagerModel _managerSelected;
		private SuperModel _superSelected;

		private ObservableCollection<SuperModel> _tableElements = new ObservableCollection<SuperModel>();
		private ObservableCollection<ManagerModel> _tableManagers = new ObservableCollection<ManagerModel>();

		public ObservableCollection<SuperModel> TableElements
		{
			get
			{
				return _tableElements;
			}
		}

		public ObservableCollection<ManagerModel> TableManagers
		{
			get
			{
				return _tableManagers;
			}
		}

		public List<Place> TablePlace
		{
			get
			{
				return _TablePlace;
			}
		}

		public List<State> TableState
		{
			get
			{
				return _TableState;
			}
		}

		public List<WorkType> TableWorkType
		{
			get
			{
				return _TableWorkType;
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
				OnPropertyChanged("SelectedItemPlace");
			}
		}

		public WorkType SelectedItemWorkType
		{
			get
			{
				return _selectedItemWorkType;
			}
			set
			{
				_selectedItemWorkType = value;
				OnPropertyChanged("SelectedItemWorkType");
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
				OnPropertyChanged("SelectedItemState");
			}
		}

		public SuperModel SuperSelected
		{
			get
			{
				return _superSelected;
			}
			set
			{
				_superSelected = value;
				OnPropertyChanged("SuperSelected");
				RefreshManagers();
			}
		}

		public ManagerModel ManagerSelected
		{
			get
			{
				return _managerSelected;
			}
			set
			{
				_managerSelected = value;
				OnPropertyChanged("ManagerSelected");
			}
		}

		public int SuperSelectedIndex
		{
			get
			{
				return _superSelectedIndex;
			}
			set
			{
				_superSelectedIndex = value;
				_managerSelectedIndex = -1;
				OnPropertyChanged("SuperSelectedIndex");
				OnPropertyChanged("ManagerSelectedIndex");

				if (SuperSelectedIndex != -1)
				{
					EditIsEnabled = true;
					if (_userRights.IsEditEnabled)
					{
						AddingManagerIsEnabled = true;
						DeleteIsEnabled = true;
					}
				}
				else
				{
					EditIsEnabled = false;
					AddingManagerIsEnabled = false;
					DeleteIsEnabled = false;
				}
			}
		}

		public int ManagerSelectedIndex
		{
			get
			{
				return _managerSelectedIndex;
			}
			set
			{
				_managerSelectedIndex = value;
				_selectedTableId = 1;
				OnPropertyChanged("ManagerSelectedIndex");
				if (ManagerSelectedIndex != -1)
				{
					EditIsEnabled = true;
					AddingManagerIsEnabled = false;
					if(_userRights.IsEditEnabled)
						DeleteIsEnabled = true;
				}
				else
				{
					EditIsEnabled = false;
					AddingManagerIsEnabled = false;
					DeleteIsEnabled = false;
				}
			}
		}

		public bool EditIsEnabled
		{
			get
			{
				return _editIsEnabled;
			}
			set
			{
				_editIsEnabled = value;
				OnPropertyChanged("EditIsEnabled");
			}
		}

		public bool AddingManagerIsEnabled
		{
			get
			{
				return _addingManagerIsEnabled;
			}
			set
			{
				_addingManagerIsEnabled = value;
				OnPropertyChanged("AddingManagerIsEnabled");
			}
		}

		public bool DeleteIsEnabled
		{
			get
			{
				return _deleteIsEnabled;
			}
			set
			{
				_deleteIsEnabled = value;
				OnPropertyChanged("DeleteIsEnabled");
			}
		}

		public string EditOrPreviewText
		{
			get
			{
				if (_userRights.IsEditEnabled)
					return " Изменить";
				else
					return " Просмотреть";
			}
		}

		public bool AddingPartnerIsEnabled
		{
			get
			{
				return _userRights.IsEditEnabled;
			}
		}

		public bool ExportIsEnabled
		{
			get
			{
				return _userRights.IsExportToExcelEnabled;
			}
		}

		public string ComboboxSearch
		{
			get { return "В данном элементе поддерживается поиск. Поместите курсор на строку и начните набирать символы."; }
		}

		private string _cursorType;

		public string CursorType
		{
			get { return _cursorType; }
		}
	}
}
