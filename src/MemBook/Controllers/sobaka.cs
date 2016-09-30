using Microsoft.AspNetCore.Mvc;

namespace MemBook.Controllers
{
    public class Sobaka : Controller
    {
        // GET: /sobaka/
        public string Index()
        {
            return "собака съела товар";
        }
        public IActionResult Memes()
        {
            return View();
        }
    }
}
