/*
 * Preston Loveland
 * Assignment 9
 * Section 1 Group 11
 * */
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
        private IMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
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
        public IActionResult MovieEntry(Movie movie)
        {
            if (ModelState.IsValid)
            {

                _repository.AddMovie(movie);
                _repository.Save();
                return View("MovieList", _repository.Movies);
            }
            return View();
        }
        //Action For Movie List
        public IActionResult MovieList()
        {
            return View(_repository.Movies);
        }
        //Action For podcasts page
        public IActionResult Podcasts()
        {
            return View();
        }

        //action to go to edit page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = _repository.GetMovieById(id);
            return View(movie);
        }

        //action to change edits made
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.UpdateMovie(movie);
                    _repository.Save();
                    return RedirectToAction("MovieList");
                }
            }
            catch (DataMisalignedException)
            {
                ModelState.AddModelError("", "Couldn't save changes");
            }
            return View(movie);
        }

        //action to delete movie from list
        [HttpPost]
        public IActionResult Delete(int movieId)
        {
            try
            {
                Movie movie = _repository.GetMovieById(movieId);
                _repository.DeleteMovie(movieId);
                _repository.Save();
            }
            catch (DataMisalignedException)
            {
                ModelState.AddModelError("", "Couldn't delete movie");
            }

            return View("MovieList", _repository.Movies);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
