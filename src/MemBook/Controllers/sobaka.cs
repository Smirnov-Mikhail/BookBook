﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MemBook.Controllers
{
    public class sobaka : Controller
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