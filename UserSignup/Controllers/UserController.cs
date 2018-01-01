using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using UserSignup.ViewModel;

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        static string name = "Default";

        public IActionResult Index()
        {
            User user = new User();

            return View(user);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            User user = new User();

            user.username = addUserViewModel.name;
            user.email = addUserViewModel.email;
            user.password = addUserViewModel.password;

            if (addUserViewModel.password != addUserViewModel.verify)
            {
                return View(addUserViewModel);
            }
            else
            {
                user.SetUser(user);
                return Redirect("/User");
            }

        }
    }
}