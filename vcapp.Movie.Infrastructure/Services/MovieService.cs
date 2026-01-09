using vcapp.Movies.Application.Interfaces;
using vcapp.Movies.Domain.Models;

namespace vcapp.Movies.Infrastructure.Services
{

    public class MovieService : IMovieService
    {
        private static readonly List<Movie> Movies = new()
    {
        new Movie {  Title = "Inception", Genre = "Sci-Fi", Year = 2010 },
        new Movie { Title = "The Godfather", Genre = "Crime", Year = 1972 },
        new Movie { Title = "The Dark Knight", Genre = "Action", Year = 2008 },
    };

        public IEnumerable<Movie> GetAll()
        {
            return Movies;
        }

        public Movie? GetById(Guid id)
        {
            return Movies.FirstOrDefault(c => c.Id == id);
        }
    }
}