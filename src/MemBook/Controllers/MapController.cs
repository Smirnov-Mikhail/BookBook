using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemBook.Models;
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
