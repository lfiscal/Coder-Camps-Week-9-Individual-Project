using MovieApp.Data.Models;
using MovieApp.Web.Adapters;
using MovieApp.Web.Adapters.Interfaces;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieApp.Web.Controllers
{
    public class ApiMovieController : ApiController
    {
        private iMovie _adapter;
        public ApiMovieController()
        {
            _adapter = new MovieAdapter();
        }
        public IHttpActionResult GET(int id = -1)
        {
            {
                return Ok(_adapter.GetMovie(id));
            }
        }
        [HttpPost]
        public IHttpActionResult POST(UserMovieVM vm)
        {
            
            return Ok(_adapter.AddMovie(vm));
        }
        public IHttpActionResult DELETE(int id)
        {
            _adapter.DeleteMovie(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult PUT(int id, Movie movie)
        {
            _adapter.UpdateMovie(id, movie);
            return Ok();
        }
    }
}
