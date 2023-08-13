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
  public class FlavorsController : Controller
  {
    private readonly TreatShopContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public FlavorsController(UserManager<ApplicationUser> userManager, TreatShopContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Description");
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Flavor> userFlavors = _db.Flavors
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .ToList();
      ViewBag.Title = "Flavors List";
      return View(userFlavors);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor)
    {
      if (!ModelState.IsValid)
      {
        return View(flavor);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        flavor.User = currentUser;
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
      }
    }
  }
}
