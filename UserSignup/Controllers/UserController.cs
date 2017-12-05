using Microsoft.AspNetCore.Mvc;
using UserSignup.ViewModels;

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(int userId)
        {
            if (userId == 0)
            {
                //User user = new User();
                //return View(user);
                return View();
            } else
            {

                User user = UserData.GetById(userId);
                return View(user);
            }

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
                user = new User ()
                {
                    Username = addUserViewModel.Username,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password
                };

                UserData.Add(user);

                return Redirect(string.Format("/Index?id={0}", user.UserId));
            }


            return View(addUserViewModel);
        }


        }
    }

