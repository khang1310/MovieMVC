using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MovieReadRepository : EFCoreReadCommandRepository<Movie, WebApplication1Context>
    {
        public MovieReadRepository(WebApplication1Context context) : base(context)
        {
        }
    }
}
