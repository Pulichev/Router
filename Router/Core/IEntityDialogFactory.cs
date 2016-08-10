namespace Core 
{
    public interface IEntityDialogFactory 
	{
        IEntityDialog GetEntityDialog(string dialogName);
    }
}
