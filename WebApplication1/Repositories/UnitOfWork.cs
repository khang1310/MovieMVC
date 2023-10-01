using System;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Repositories
{
    public class UnitOfWork
    {
        private WebApplication1Context context;
        private IRepository<Movie>? movieRepository;

        public UnitOfWork(WebApplication1Context context)
        {
            this.context = context;
        }

        public IRepository<Movie>? MovieRepository
        {
            get
            {
                if(movieRepository == null)
                {
                    movieRepository = new EfCoreMovieRepository(context);
                }
                return movieRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
