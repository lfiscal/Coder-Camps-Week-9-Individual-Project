using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string Fav { get; set; }
        public string Password { get; set; }
        public User(){}
        public User(string applicationUserId, string name, string fav, string picUrl) 
        {
            ApplicationUserId = applicationUserId;
            Name = name;
            Fav = fav;
            PicUrl = picUrl;
        }
    }
}
