using vcapp.Movies.Infrastructure.Services;

namespace MovieTest
{
    public class MovieServiceTest
    {
                
        [Fact]
        public void GetAllMovies_ShouldReturnList()
        {
            var service = new MovieService();
            var result = service.GetAll();
            Assert.NotEmpty(result);
        }
    }
}