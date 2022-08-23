namespace AdminCore.Repository
{
    public interface IRepository<TEntity>  where TEntity : class
    {
         Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task Update(int id,TEntity entity);
        Task<TEntity> Delete(int id);

    }
}
