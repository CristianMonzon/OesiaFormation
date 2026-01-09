namespace vcapp.Movies.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

    }
}
