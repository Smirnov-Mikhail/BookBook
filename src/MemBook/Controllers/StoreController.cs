﻿using System.Linq;
using MemBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MemBook.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StoreController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: /store/
        public IActionResult Catalog()
        {
            return View(_db.Books.ToList());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult BookInfo(int id)
        {
            var bookId = _db.Books.FirstOrDefault(x => x.Id == id);
            ViewBag.Annotation = bookId.Annotation;
            ViewBag.ImagePath = Url.Content("~/images/books/" + bookId.ImageUrl);
            ViewBag.BookId = id;
            ViewBag.Price = bookId.Price;
            return View();
        }

        [Authorize]
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
