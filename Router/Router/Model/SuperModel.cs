using Data;

namespace Router.Model
{
	public class SuperModel : PropertyChangeEventBase
	{
		private Super _item;

		private bool _isSelected;
		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
				OnPropertyChanged("IsSelected");
			}
		}

		public SuperModel(Super item)
		{
			_item = item;
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

		public string Location
		{
			get { return _item.Location; }
			set
			{
				_item.Location = value;
				OnPropertyChanged("Location");
			}
		}

		public string TerritoryType
		{
			get { return _item.TerritoryType; }
			set
			{
				_item.TerritoryType = value;
				OnPropertyChanged("TerritoryType");
			}
		}

		public string Company
		{
			get { return _item.Company; }
			set
			{
				_item.Company = value;
				OnPropertyChanged("Company");
			}
		}


		public string Head
		{
			get { return _item.Head; }
			set
			{
				_item.Head = value;
				OnPropertyChanged("Head");
			}
		}

		public string Phone
		{
			get { return _item.Phone; }
			set
			{
				_item.Phone = value;
				OnPropertyChanged("Phone");
			}
		}

		public string EMail
		{
			get { return _item.EMail; }
			set
			{
				_item.EMail = value;
				OnPropertyChanged("EMail");
			}
		}

		public string State
		{
			get { return _item.State; }
			set
			{
				_item.State = value;
				OnPropertyChanged("State");
			}
		}

		public int PlaceId
		{
			get { return _item.PlaceId; }
			set
			{
				_item.Id = value;
				OnPropertyChanged("PlaceId");
			}
		}
	}
}
