namespace Core 
{
    public interface IDialogManager 
	{
        bool RaiseDialog<TEntity>(string dialogName, ref TEntity data);
    }
}
