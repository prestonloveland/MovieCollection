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
    //base to inherit from in controller to set up a queryable with book objects
    public interface IMovieRepository
    {
        //base for EFRepo class and methods
        IQueryable<Movie> Movies { get; }
        void AddMovie(Movie movie);
        void Save();
        Movie GetMovieById(int MovieId);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int movieId);

    }
}
