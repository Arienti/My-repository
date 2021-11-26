using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //API END POINT !!!!!!!!!!!!!!!!!!!
        public IActionResult test()
        {
            return View();
        }
        //https://localhost:44396/Home/time
        public ActionResult time()
        {  //200 HTTP OK

            var result = Content("<html><head><meta http-equiv=\"refresh\" content=\"1\"></head><body>" + DateTime.Now.ToString() + "</body></html>");
            result.ContentType = "text/html; charset=UTF-8";

            return result;            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
