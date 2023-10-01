using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class StarRepository : EfCoreRepository<Star, WebApplication1Context>
    {
        public StarRepository(WebApplication1Context context) : base(context)
        {

        }
    }
}
