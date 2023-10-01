using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class EfCoreMovieRepository : EfCoreRepository<Movie, WebApplication1Context>
    {
        public EfCoreMovieRepository(WebApplication1Context context) : base(context)
        {
        }

        public bool MovieExists(int id)
        {
            return context.Movie.Any(e => e.Id == id);
        }
    }
}
