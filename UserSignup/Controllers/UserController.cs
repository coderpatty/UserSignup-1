using Microsoft.AspNetCore.Mvc;
using UserSignup.ViewModels;

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel, User user)
        {
            if (user == null) user = new User();

            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                user = new User ()
                {
                    Username = addUserViewModel.Username,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password
                };

                UserData.Add(user);

                //return View("Index", user);
            }


            return View("Index", user);
        }


        }
    }

