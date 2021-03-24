/*
 * Preston Loveland
 * Assignment 9
 * Section 1 Group 11
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    //class to record information on a movie entry
    public class Movie
    {
        [Key, Required]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public string Edited { get; set; }

        public string Lent_To { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
