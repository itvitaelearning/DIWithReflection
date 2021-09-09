using Microsoft.AspNetCore.Mvc;
using OwnLogger.Business;
using OwnLogger.Business.Interfaces;

namespace OwnLogger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly ILogger logger;

        public MovieController(IMovieService movieService, ILogger logger)
        {
            this.movieService = movieService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            logger.Log("GetAll!");
            return Ok(movieService.GetAllmovies());
        }
    }
}
