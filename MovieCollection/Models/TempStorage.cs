using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public static class TempStorage
    {
        //create list
        private static List<MovieEntry> movies = new List<MovieEntry>();
        //create an application
        public static IEnumerable<MovieEntry> Movies => movies;
        //add the application to the list
        public static void AddMovie(MovieEntry movie)
        {
            movies.Add(movie);
        }
    }
}
