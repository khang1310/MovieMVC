namespace WebApplication1.Data
{
    public interface IEFCoreReadCommandRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
    }
}
