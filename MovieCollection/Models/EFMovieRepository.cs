/*
 * Preston Loveland
 * Assignment 9
 * Section 1 Group 11
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDbContext _context;

        //Constructor
        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        
        //methods to alter the database repo through Adding, saving, deleting, and updating
        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void DeleteMovie(int movieId)
        {
            Movie movie = _context.Movies.Find(movieId);
            _context.Movies.Remove(movie);
        }

        public IQueryable<Movie> Movies => _context.Movies;
    }
}
