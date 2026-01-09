using Microsoft.AspNetCore.Mvc;
using vcapp.Movies.Infrastructure.Services;
using vcapp.Movies.Domain.Models;

namespace VideoClub.MoviesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerServices _service;
        public CustomerController(CustomerServices service)
        {
            _service = service;
        }

        [HttpGet(Name = "GellAll")]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            try
            {
                var movies = _service.GetAllCustomers();
                if (movies == null || !movies.Any()) return NoContent(); // 204
                return Ok(movies); // 200
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

    }
}


