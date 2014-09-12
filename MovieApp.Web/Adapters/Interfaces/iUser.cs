using MovieApp.Data.Models;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Web.Adapters.Interfaces
{
    public interface iUser
    {
        UserMovieVM GetUser(int id);
        List<User> GetAllUsers();
        User NewUser(User newUser);
        void UpdateUserInfo(int id, User user);
        void DeleteAccount(int id);
    }
}
