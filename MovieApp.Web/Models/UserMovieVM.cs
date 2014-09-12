using MovieApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Web.Models
{
    public class UserMovieVM
    {
        public User User { get; set; }
        public List<Movie> Movies { get; set; }
        public Movie Movie { get; set; }
    }
}