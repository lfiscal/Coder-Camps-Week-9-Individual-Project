using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class UserAdapter : iUser
    {
        public User NewUser(User newUser)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            var UserStore = new UserStore<ApplicationUser>(Db);
            var UserManager = new UserManager<ApplicationUser>(UserStore);

            if (!Db.Users.Any(u => u.UserName == newUser.Name)) 
            {
                ApplicationUser User = new ApplicationUser();
                User.UserName = newUser.Name;
                UserManager.Create(User, newUser.Password);
                UserManager.AddToRole(User.Id, "User");
            }
            User WebUser = new User(Db.Users.Where(u => u.UserName == newUser.Name).FirstOrDefault().Id, newUser.Name, newUser.Fav, newUser.PicUrl);
            Db.WebUsers.Add(WebUser);
            Db.SaveChanges();

            return newUser;
        }

        public UserMovieVM GetUser(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            UserMovieVM VM = new UserMovieVM();
            VM.User = Db.WebUsers.Where(u => u.Id == id).FirstOrDefault();
            VM.Movies = Db.Movies.Where(m => m.UserId == id).ToList();
            return VM;
        }

        public List<User> GetAllUsers()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.WebUsers.ToList();

        }

        public void UpdateUserInfo(int id, User user)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            User UserUpdate = Db.WebUsers.Where(u => u.Id == id).FirstOrDefault();
            UserUpdate.Fav = user.Fav;
            UserUpdate.PicUrl = user.PicUrl;
            Db.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            User UserToDelete = Db.WebUsers.Where(c => c.Id == id).FirstOrDefault();
            Db.WebUsers.Remove(UserToDelete);
            Db.SaveChanges();
        }
    }
}