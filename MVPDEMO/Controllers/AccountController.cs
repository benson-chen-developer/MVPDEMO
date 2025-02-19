using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserRepository _userRepository;

        public AccountController(IWebHostEnvironment webHostEnvironment, UserRepository userRepository)
        {
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterSubmitted(User model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };

                _userRepository.AddUser(newUser);

                return View("Success", model);
            }

            return View(model);
        }
    }
}
