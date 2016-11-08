using Microsoft.AspNetCore.Mvc;

namespace MemBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
