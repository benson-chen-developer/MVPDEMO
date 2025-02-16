using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    
    public class ProductController : Controller
    {


        
        public IActionResult Details()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 999.99m
            };

            return View(product); 
        }

        public IActionResult LooselyTyped()
        {
            ViewBag.ProductName = "Smartphone";
            ViewData["ProductPrice"] = 599.99m;
            return View();
        }



        //[ServiceFilter(typeof(UppercaseActionFilter))]
        public IActionResult Message()
        {
            ViewData["ViewDataMessage"] = "Hello from ViewData!";
            ViewBag.ViewBagMessage = "Hello from ViewBag!";

            return View();
        }

        public IActionResult TempDatamessage()
        {
            TempData["Message"] = "Hello from TempData!";
            TempData["PeekMessage"] = "Hello from TempData!(Peek)";
            TempData["KeepMessage"] = "Hello from TempData!(Keep)";
            return RedirectToAction("Nextmessage");
        }

        public IActionResult Nextmessage()
        {
            var testPeek = TempData["PeekMessage"];
            TempData.Keep("KeepMessage");  
            return View();
        }
        [ResponseCache(Duration = 10)]
        public IActionResult CachedTime()
        {
            ViewData["CurrentTime"] = DateTime.Now.ToString("HH:mm:ss");
            return View();
        }

    }
}
