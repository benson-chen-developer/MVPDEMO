using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers
{
    

        public class HomeController : Controller
        {
            private readonly ISingletonService _singletonService;

            private readonly IScopedService _scopedService1;
            private readonly IScopedService _scopedService2;

            private readonly ITransientService _transientService1;
            private readonly ITransientService _transientService2;

            private readonly ILogger<HomeController> _logger;


         public HomeController(
           ISingletonService singletonService,

           IScopedService scopedService1,
           IScopedService scopedService2,
           ITransientService transientService1,
           ITransientService transientService2,

           ILogger<HomeController> logger)
            {
                _singletonService = singletonService;

                _scopedService1 = scopedService1;
                _scopedService2 = scopedService2;
                _transientService1 = transientService1;
                _transientService2 = transientService2;

                _logger = logger;
            }



        public ViewResult Index()
        {
            return View();
        }

        //public IActionResult Index()
        //{
        //    var product = new { Id = 1, Name = "Laptop", Price = 999.99 };

        //    return Json(product);
        //    return Content("Hello, this is a text response!");

        //}




        //[Route("Attributerouting")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Crash()
        {
            throw new Exception("This is a test error!");
        }

    

        public IActionResult ServiceLifetimes()
        {
            ViewData["Singleton"] = _singletonService.GetInstanceInfo();
            ViewData["Scoped1"] = _scopedService1.GetInstanceInfo();
            ViewData["Transient1"] = _transientService1.GetInstanceInfo();

            ViewData["Scoped2"] = _scopedService2.GetInstanceInfo();
            ViewData["Transient2"] = _transientService2.GetInstanceInfo();

            return View();
        }

    }
}
