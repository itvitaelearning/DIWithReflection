
using OwnLogger.Business.Entities;
using OwnLogger.Business.Interfaces;
using System.Collections.Generic;

namespace OwnLogger.Business
{
    public class MovieService: IMovieService
    {
        private readonly ILogger logger;

        public MovieService(ILogger logger)
        {
            this.logger = logger;
        }

        public IEnumerable<Movie> GetAllmovies()
        {
            logger.Log("Getting all movies", Microsoft.Extensions.Logging.LogLevel.Information);

            return new List<Movie> { 
                new Movie
                {
                    Description = "Description 001",
                    Title = "001",
                    Id = 1
                },
                new Movie
                {
                    Description = "Description 002",
                    Title = "002",
                    Id = 2
                }
            };
        }
    }
}
