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
      return View(userTreats);
    }
    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [Authorize]
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
    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
          .Include(treat => treat.JoinEntities)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Profile");
      return View(thisTreat);
    }
    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
      Treat modelTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);

      if (modelTreat == null)
      {
        return NotFound();
      }

      if (!User.Identity.IsAuthenticated)
      {
        return View("Unauthorized");
      }

      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

      if (currentUser == modelTreat.User)
      {
        return View(modelTreat);
      }
      else
      {
        return RedirectToAction("Accounts", "Index");
      }
    }


    [HttpPost]
    [Authorize]
    public ActionResult Edit(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        _db.Treats.Update(treat);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = treat.TreatId });
      }
      return RedirectToAction("Index", "Home");
    }


    [HttpPost]
    [Authorize]
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
      if (!User.Identity.IsAuthenticated)
      {
        return View("Unauthorized");
      }
#nullable enable
      TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
#nullable disable
      if (joinEntity == null && flavorId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = flavorId, TreatId = treat.TreatId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = treat.TreatId });
    }
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      if (currentUser == thisTreat.User)
      {
        return View(thisTreat);
      }
      else
      {
        return View("Unauthorized");
      }
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

  }
}
