using MovieApp.Data;
using MovieApp.Data.Models;
using MovieApp.Web.Adapters.Interfaces;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Web.Adapters
{
    public class MovieAdapter : iMovie
    {
        public Movie GetMovie(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie Movie = new Movie();
            Movie = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            return Movie;
        }

        public List<Movie> GetMovies(int userId)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.Movies.ToList();
        }

        public int AddMovie(UserMovieVM vm)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie Movie = new Movie();
            vm.Movie.UserId = vm.User.Id;
            Db.Movies.Add(vm.Movie);
            Db.SaveChanges();
            return vm.Movie.UserId;
        }

        public void UpdateMovie(int id, Movie updatedMovie)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie MovieUpdate = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            MovieUpdate.Title = updatedMovie.Title;
            MovieUpdate.Actors = updatedMovie.Actors;
            MovieUpdate.Country = updatedMovie.Country;
            MovieUpdate.Director = updatedMovie.Director;
            MovieUpdate.Genre = updatedMovie.Genre;
            MovieUpdate.imdbRating = updatedMovie.imdbRating;
            MovieUpdate.Language = updatedMovie.Language;
            MovieUpdate.Plot = updatedMovie.Plot;
            MovieUpdate.Poster = updatedMovie.Poster;
            MovieUpdate.Rated = updatedMovie.Rated;
            MovieUpdate.Released = updatedMovie.Released;
            MovieUpdate.Runtime = updatedMovie.Runtime;
            MovieUpdate.Status = updatedMovie.Status;
            MovieUpdate.Year = updatedMovie.Year;
        }

        public void DeleteMovie(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie MovieToDelete = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            Db.Movies.Remove(MovieToDelete);
            Db.SaveChanges();
        }
    }
}