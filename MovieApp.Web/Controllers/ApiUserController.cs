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
    public class ApiUserController : ApiController
    {
        private iUser _adapter;

        public ApiUserController() 
        {
            _adapter = new UserAdapter();
        }
        public IHttpActionResult GET(int id = -1) 
        {
            if (id == -1)
            {
                return Ok(_adapter.GetAllUsers());
            }
            else 
            {
                return Ok(_adapter.GetUser(id));
            }
        }
        [HttpPost]
        public IHttpActionResult POST(User newUser)
        {
            return Ok(_adapter.NewUser(newUser));
        }
        public IHttpActionResult DELETE(int id) 
        {
            _adapter.DeleteAccount(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult PUT(int id, User user) 
        {
            _adapter.UpdateUserInfo(id, user);
            return Ok();
        }
    }
}
