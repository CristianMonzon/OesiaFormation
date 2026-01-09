namespace VideoClub.RentalsService.Models
{
    public class Rental
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid MovieId { get; set; }

        public Guid CustomerId { get; set; }    

        public DateTime RentalDate { get; set; } = DateTime.UtcNow;

    }
}
