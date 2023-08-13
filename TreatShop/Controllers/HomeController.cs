using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TreatShop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace TreatShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly TreatShopContext _db;
        public HomeController(TreatShopContext db)
        {
            _db = db;
        }
        [HttpGet("/")]
        public ActionResult Index()
        {
             List<Treat> treats = _db.Treats.ToList(); 
            return View(treats); 
        }
    }
}