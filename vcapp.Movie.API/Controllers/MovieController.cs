using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vcapp.Movies.Application.Interfaces;
using vcapp.Movies.Domain.Models;


namespace vcapp.Movies.API.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            try
            {
                var movies = _service.GetAll();
                if (movies == null || !movies.Any()) return NoContent(); // 204
                return Ok(movies); // 200
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Movie?> GetById(Guid id)
        {
            try
            {
                var movie = _service.GetById(id);
                if (movie == null) return NoContent(); // 204
                return Ok(movie); // 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }
    }
}
