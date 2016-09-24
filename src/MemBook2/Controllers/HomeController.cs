using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
