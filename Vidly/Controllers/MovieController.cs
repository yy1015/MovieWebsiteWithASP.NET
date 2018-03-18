using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;


namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _dbContext;

        public MovieController()
        {
            _dbContext = new MovieDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Movie
        //public ActionResult Random()
        //{
        //    var movie = new Movie()
        //    {
        //        Name = "Shrek"
        //    };
        //    //return View(movie);
        //    //return Content("hello world");
        //    // return HttpNotFound();
        //    //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });
        //    //ViewData["Movie"] = movie;
        //    var customers = new List<Customer>
        //    {
        //        new Customer()
        //        {
        //            Name = "customer1"
        //        },
        //        new Customer()
        //        {
        //            Name = "customer2"
        //        }

        //    };
        //    var model = new RandomMovieViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers

        //    };
        //    return View(model);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content($"id = {id}");
        //}
        //[Route("movies/released/{year}/{month:regex(\\d{2})}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        public ActionResult Index()
        {
            var movies = _dbContext.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult NewMovieView()
        {
            var genres = _dbContext.Genres.ToList();
            var movieViewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            //throw new System.NotImplementedException();
            return View(movieViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            // throw new System.NotImplementedException();
            if (movie.Id == 0)
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _dbContext.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleasedTime = movie.ReleasedTime;
                movieInDb.AddedDate = movie.AddedDate;
                movieInDb.GenreId = movie.GenreId;

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Movie");

        }

        public ActionResult Edit(int id)
        {
            // throw new System.NotImplementedException();
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            var movieViewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _dbContext.Genres

            };
            return View("NewMovieView", movieViewModel);
        }
    }
}