using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterSubmitted(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Success", model);
            }

            return View(model);
        }
    }
}
