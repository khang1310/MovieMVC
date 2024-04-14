using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repositories
{
    public abstract class EFCoreReadCommandRepository<TEntity, TContext> : IEFCoreReadCommandRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext context;

        public EFCoreReadCommandRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
    }
}
