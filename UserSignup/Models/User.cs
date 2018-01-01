using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSignup.Models
{
    public class User
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User()
        {
        }

        static private User staticUser;

        public void SetUser(User user)
        {
            staticUser = user;
        }

        public User GetUser()
        {
            return staticUser;
        }
    }
}