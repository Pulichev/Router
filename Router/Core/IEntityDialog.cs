namespace Core 
{
    public interface IEntityDialog 
	{
    }

    public interface IEntityDialog<TEntity> : IEntityDialog 
	{
        void SetEntity(TEntity entity);
        TEntity GetEntity();
    }
}
