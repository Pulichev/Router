namespace Router.Model
{
	public abstract class SuperDetailsCheckedModel<TValue> : PropertyChangeEventBase
	{
		private TValue _item;
		protected SuperDetailsModel _parent;
		private bool _checked;
		private bool _isEnabled;

		public SuperDetailsCheckedModel(bool IsEnabled, SuperDetailsModel parent, TValue item, bool chk)
		{
			_isEnabled = IsEnabled;
			_item = item;
			_checked = chk;
			_parent = parent;
		}

		public TValue Element
		{
			get { return _item; }
		}

		public bool Checked
		{
			get { return _checked; }
			set
			{
				_checked = value;
				if (_checked)
					Add();
				else
					Remove();
				OnPropertyChanged("Checked");
			}
		}

		public bool ElementsIsEnabled
		{
			get { return _isEnabled; }
		}

		protected abstract void Add();
		protected abstract void Remove();
	}
}