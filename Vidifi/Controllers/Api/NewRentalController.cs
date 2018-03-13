using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidifi.Dtos;
using Vidifi.Models;

namespace Vidifi.Controllers.Api
{
    public class NewRentalController : ApiController

    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
       public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids have been given.");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            

            if (customer == null)
            {
                return BadRequest("CustomerId is not valid.");
            }


            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            if (movies.Count() != newRental.MovieIds.Count())
            {
                return BadRequest("Movie is not available");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}