using Microsoft.AspNetCore.Mvc;

namespace MovieWebApp.Controllers
{
    public class HelloWorldController : Controller
    {
        [HttpGet("/HelloWorld")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/HelloWorld/Welcome/{name}/{id}")]
        public IActionResult Welcome(string name, int id = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["ID"] = id;

            return View();
        }
    }
}
