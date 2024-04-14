namespace WebApplication1.Data
{
    public interface IEFCoreWriteCommandRepository<T> where T : class, IEntity
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
