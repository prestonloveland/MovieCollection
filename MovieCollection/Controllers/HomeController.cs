using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Action for Index Page
        public IActionResult Index()
        {
            return View();
        }
        //for Get to Movie Entry
        [HttpGet]
        public IActionResult MovieEntry()
        {
            return View();
        }
        //for Post to Movie Entry
        [HttpPost]
        public IActionResult MovieEntry(MovieEntry movie)
        {
            if (ModelState.IsValid)
            {
                TempStorage.AddMovie(movie);
                return View("MovieList", TempStorage.Movies);
            }
            return View();
        }
        //Action For Movie List
        public IActionResult MovieList()
        {
            return View(TempStorage.Movies);
        }
        //Action For poscasts page
        public IActionResult Podcasts()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
