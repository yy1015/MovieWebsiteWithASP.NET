using System;
using System.Linq;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalController : ApiController
    {
        private readonly MovieDbContext _context;
        public NewRentalController()
        {
            _context = new MovieDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto rentalDto)
        {
            if (rentalDto.MovieId.Count == 0)
            {
                return BadRequest("Movie id is not given");

            }

            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);

            if (customer == null)
            {
                return BadRequest("Customer id is not valid");
            }
            var movies = _context.Movies.Where(m => rentalDto.MovieId.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieId.Count)
            {
                return BadRequest("One or more movies are invalid");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }
                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    RentalDate = DateTime.Now

                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }


}
