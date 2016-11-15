using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MemBook.Controllers
{
    public class AdminPageController : Controller
    {
        // GET: /adminPage/
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AdminPageController(IHostingEnvironment hostingEnvironment,ApplicationDbContext context)
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
        public async Task<RedirectToActionResult> UploadFiles(Book book,ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "images/books");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        book.ImageUrl = file.FileName;
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return null;
        }


    }
}
