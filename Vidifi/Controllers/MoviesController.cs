using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidifi.Models;

namespace Vidifi.Controllers
{
    public class MoviesController : Controller

    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = getMovies();
            
           
            return View(movies);
        }

        private IEnumerable<Movie> getMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Harry Potter" },
                new Movie { Id = 2, Name = "Pitch Perfect" }
            };
        }
    }
}