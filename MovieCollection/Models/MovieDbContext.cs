/*
 * Preston Loveland
 * Assignment 9
 * Section 1 Group 11
 * */
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    //inherits from DBContext
    public class MovieDbContext : DbContext
    {
        // inherits from base options
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
