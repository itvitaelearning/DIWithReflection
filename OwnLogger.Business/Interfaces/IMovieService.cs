using OwnLogger.Business.Entities;
using System.Collections.Generic;

namespace OwnLogger.Business
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllmovies();
    }
}