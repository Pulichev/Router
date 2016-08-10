using Router.Model;

namespace Router.ViewModel
{
	public class SuperDetailsViewModel : PropertyChangeEventBase 
	{
		public void SetEntity(SuperDetailsModel entity)
		{
			Entity = entity;
     	    OnPropertyChanged("Entity");
        }

		public SuperDetailsModel Entity { get; private set; }
	}
}