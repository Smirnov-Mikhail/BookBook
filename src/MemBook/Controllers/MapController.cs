using Microsoft.AspNetCore.Mvc;

namespace MemBook.Controllers
{
    public class MapController : Controller
    {
        // GET: /<controller>/
        public IActionResult MapAddress()
        {
            return View();
        }
    }
}
