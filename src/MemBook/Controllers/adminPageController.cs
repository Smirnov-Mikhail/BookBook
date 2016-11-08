using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MemBook.Controllers
{
    public class adminPageController : Controller
    {
        // GET: /adminPage/
        private readonly ApplicationDbContext _db;
        public adminPageController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            ViewBag.roles = _db.Roles.ToList<IdentityRole>();
            return View();
        }
    }
}
