using vcapp.Movies.Domain.Models;

namespace vcapp.Movies.Application.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();

        Movie? GetById(Guid id);
    }
}
