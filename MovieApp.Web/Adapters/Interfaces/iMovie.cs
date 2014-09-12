using MovieApp.Data.Models;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Web.Adapters.Interfaces
{
    public interface iMovie
    {
        Movie GetMovie(int id);
        List<Movie> GetMovies(int userId);
        int AddMovie(UserMovieVM newMovie);
        void UpdateMovie(int id, Movie updatedMovie);
        void DeleteMovie(int id);
    }
}
