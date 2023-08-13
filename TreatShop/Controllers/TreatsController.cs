using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TreatShop.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace TreatShop.Controllers
{
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly TreatShopContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public TreatsController(UserManager<ApplicationUser> userManager, TreatShopContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Profile");
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Treat> userTreats = _db.Treats
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .ToList();
      ViewBag.Title = "Treats List";
      return View(userTreats); 
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        treat.User = currentUser;
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
      }
    }
  }
}
