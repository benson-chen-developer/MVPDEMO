using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class HomeController : Controller
{
    private readonly UserRepository _userRepository;

    public HomeController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        var users = _userRepository.GetAllUsers();

        Console.WriteLine("Fetched Users", users);
        return View(users); // Pass users to the view
    }
}
