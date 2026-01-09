using Microsoft.Extensions.DependencyInjection;
using vcapp.Movies.Application.Interfaces;
using vcapp.Movies.Infrastructure.Services;

namespace vcapp.Movies.Infrastructure
{
    
    public static class DependencyJnjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Aquí puedes registrar los servicios de infraestructura, como bases de datos, repositorios, etc.

            services.AddSingleton<IMovieService, MovieService>();
            return services;
        }   
    }
}
