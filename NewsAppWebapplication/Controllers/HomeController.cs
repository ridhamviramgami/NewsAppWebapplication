using Microsoft.AspNetCore.Mvc;
using NewsAppWebapplication.Models;
using System.Diagnostics;

namespace NewsAppWebapplication.Controllers
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
            try
            {
                //return html view from controller
                return View();
            }
            catch (Exception ex)
            {
                //find log for error
                Console.WriteLine(ex + " : " + DateTime.Now);
                throw;
            }
        }
    }
}