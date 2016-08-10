using Core;
using Router.ViewModel;
using Router.View;

namespace Router.Dialogs
{
	public class DialogFactory : IEntityDialogFactory
	{
		public IEntityDialog GetEntityDialog(string dialogName)
		{
			if (string.Equals(dialogName, "NewSuper"))
				return (new SuperView());
			if (string.Equals(dialogName, "NewManager"))
				return (new ManagerView(new ManagerDetailsViewModel()));
			return null;
		}
	}
}
