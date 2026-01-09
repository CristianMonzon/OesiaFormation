namespace vcapp.Movies.Domain.Models
{
    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

    }
}
