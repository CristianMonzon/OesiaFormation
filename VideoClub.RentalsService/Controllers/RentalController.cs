using Microsoft.AspNetCore.Mvc;
using VideoClub.RentalsService.Models;
using VideoClub.RentalsService.Services;

namespace VideoClub.MoviesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : Controller
    {
        private readonly RentalService _service;
        public RentalController(RentalService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<Rental>> GetAll()
        {
            try
            {
                var movies = _service.GetAllRentals();
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


