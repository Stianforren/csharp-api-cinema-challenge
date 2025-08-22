using api_cinema_challenge.DOTs.MovieDTOs;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Endpoints
{
    public static class MovieAPI
    {
        public static void ConfigueMovie(this WebApplication app)
        {
            var customerGroup = app.MapGroup("movie");

            customerGroup.MapGet("/", GetMovies);
        }

        private static async Task<IResult> GetMovies(IGenericRepository<Movie> repository)
        {
            var response = await repository.GetWithIncludes(m => m.Include(s => s.Screenings).ThenInclude(t => t.Tickets).ThenInclude(c => c.Customer));
            var result = response.Select(m => new MovieGet(m));
            return TypedResults.Ok(result);
        }
    }
}
