using Router.Model;

namespace Router.ViewModel
{
	public class ManagerDetailsViewModel : PropertyChangeEventBase
	{
		public void SetEntity(ManagerModel entity)
		{
			Entity = entity;
			OnPropertyChanged("Entity");
		}

		public ManagerModel Entity { get; private set; }
	}
}
