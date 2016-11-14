using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.IO;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MemBook.Controllers
{
    public class adminPageController : Controller
    {
        // GET: /adminPage/
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        public adminPageController(IHostingEnvironment hostingEnvironment,ApplicationDbContext context)
        {
            _db = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            ViewBag.roles = _db.Roles.ToList<IdentityRole>();
            
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult UploadFiles()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFiles(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return RedirectToAction("Add");
        }


    }
}
