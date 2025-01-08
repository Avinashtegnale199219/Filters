using System.Diagnostics;
using FilterProject.Models;
using FilterProject.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilterProject.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         
        public string NonSecureMethod()
        {
            return "This method can be accessed by everyone as it is non-secure method";
        }

        [TypeFilter(typeof(CustomResultFilterAttribute))]
        public string SecureMethod()
        {
  
            return "This method needs to be access by authorized users as it SecureMethod";
        }
        
        public string Login()
        {
            return "This is the Login Page";
        }

        [CustomAuthorizationFilterAttribute]
        public async Task<string> Login1()
        {
            return  "This is the Login Page";
        }
    }
}
