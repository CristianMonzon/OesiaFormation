namespace VideoClub.RentalsService.Services
{
    public class RentalService
    {
        public static readonly List<Models.Rental> Rentals = new()
        {
            new Models.Rental { MovieId = Guid.NewGuid(), CustomerId = Guid.NewGuid() },
            new Models.Rental { MovieId = Guid.NewGuid(), CustomerId = Guid.NewGuid() },
            new Models.Rental { MovieId = Guid.NewGuid(), CustomerId = Guid.NewGuid() },
        };

        public IEnumerable<Models.Rental> GetAllRentals()
        {
            return Rentals;
        }
    }
}
