using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using System.Text.RegularExpressions;

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        private static UserData userData;

        static UserController()
        {
            userData = UserData.GetInstance();
        }

        public IActionResult Index(User user)
        {
            if (user == null) user = new User{
                Username = "",
                Password = "",
                Email = "",
                FavColor = "" };
            //List<User> users = UserData.GetAll();
            return View(user);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Add(User user, string verify)
        {
            ViewBag.Error = null;

            if (user.Password != verify)
            {
                ViewBag.Errors += "Passwords do not match<br/>";
            }

            if(user.Username == null || user.Email == null)
            {
                ViewBag.Errors += "One or more fields are empty<br/>";
            }

            if (user.Username.Length < 5 || user.Username.Length > 15 
                || !Regex.IsMatch(user.Username, @"^[a-zA-Z]+$"))
            {
                ViewBag.Errors += "Username is invalid<br/>";
            }

            if(ViewBag.Errors)
            {
                return View();
            }
            UserData.Add(user);
            return View("Details", user.UserId);
        }


    }
}