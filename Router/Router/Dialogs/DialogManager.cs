using System;
using System.Windows;
using Core;

namespace Router.Dialogs
{
    public class DialogManager: IDialogManager 
	{
		private readonly IEntityDialogFactory _dialogFactory;
        public DialogManager(IEntityDialogFactory dialogFactory) 
		{
            _dialogFactory = dialogFactory;
        }

        public bool RaiseDialog<TEntity>(string dialogName, ref TEntity data) 
		{
            var dialog = _dialogFactory.GetEntityDialog(dialogName) as IEntityDialog<TEntity>;
            if (dialog == null) throw new InvalidOperationException("Диалог " + dialogName + " не поддерживается");
            dialog.SetEntity(data);
            var window = dialog as Window;
            if (window == null)
                throw new InvalidOperationException("Диалог типа " + dialog.GetType() + " не поддерживается.");

            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (window.ShowDialog().GetValueOrDefault(false)) {
                data = dialog.GetEntity();
                return true;
            }

            return false;
        }
    }
}