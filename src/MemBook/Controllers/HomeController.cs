using System.Linq;
using MemBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _db;
        public HomeController(BookContext context)
        {
            _db = context;
            
        }
        public IActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        //
        // GET: /test123/

        public string testController()
        {
            return "hello pes";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
