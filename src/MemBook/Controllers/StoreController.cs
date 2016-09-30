using System.Linq;
using MemBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemBook.Controllers
{
    public class StoreController : Controller
    {
        private readonly BookContext _db;
        public StoreController(BookContext context)
        {
            _db = context;
        }

        // GET: /store/
        public IActionResult Catalog()
        {
            return View(_db.Books.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _db.Orders.Add(order);
            // сохраняем в бд все изменения
            _db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}
