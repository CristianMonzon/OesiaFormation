using vcapp.Movies.Domain.Models;

namespace vcapp.Movies.Infrastructure.Services
{
    public class CustomerServices
    {

        public static readonly List<Customer> customers = new()
        {
            new Customer { Name = "John Doe", Email = "johnDoe@gmail.com" },
            new Customer { Name = "Jane Smith", Email = "jane@gmail.com" },
            new Customer { Name = "Mike Johnson", Email = "mike@gmail.com" },
        };


        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }

    }
}
