using System;
using System.ComponentModel;
using Data;
using Router.Security;

namespace Router.Model
{
	public class ManagerModel : PropertyChangeEventBase, IDataErrorInfo
	{
		private Manager _item;
		private UserGroupRights _userRights;

		public ManagerModel(Manager item)
		{
			_item = item;
		}

		public ManagerModel(Manager item, UserGroupRights userRights)
		{
			_item = item;
			_userRights = userRights;
		}

		public Manager Element
		{
			get
			{
				return _item;
			}
		}

		private bool _ButtonOkIsEnabled = true;

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

		public bool TextBoxesIsReadOnly
		{
			get
			{
				if (_userRights.IsEditEnabled)
					return false;
				else
					return true;
			}
		}

		public string FIO
		{
			get { return _item.FIO; }
			set
			{
				_item.FIO = value;
				OnPropertyChanged("FIO");
			}
		}

		public int Id
		{
			get { return _item.Id; }
			set
			{
				_item.Id = value;
				OnPropertyChanged("Id");
			}
		}

		public string Telephone
		{
			get { return _item.Telephone; }
			set
			{
				_item.Telephone = value;
				OnPropertyChanged("Telephone");
			}
		}

		public string Mail
		{
			get { return _item.Mail; }
			set
			{
				_item.Mail = value;
				OnPropertyChanged("Mail");
			}
		}

		public string Commentary
		{
			get { return _item.Commentary; }
			set
			{
				_item.Commentary = value;
				OnPropertyChanged("Commentary");
			}
		}

		public int SuperId
		{
			get { return _item.SuperId; }
			set
			{
				_item.SuperId = value;
				OnPropertyChanged("SuperId");
			}
		}

		private string _errorMessage;

		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				_errorMessage = value;
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
					case "FIO":
						if (string.IsNullOrEmpty(FIO))
						{
							msg = "Не может быть пустым";
							_errorMessage = msg;
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