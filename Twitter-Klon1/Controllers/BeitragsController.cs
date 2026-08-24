using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter_Klon1.Data;
using Twitter_Klon1.Models;

public class BeitragsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public BeitragsController(
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    // GET: BEITRAGS
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }

        var beitraege = await _context.Beitrag
            .Include(b => b.Likes)
            .Include(b => b.User)
            .Include(b => b.Dislikes)
            .OrderByDescending(b => b.ErstellungsDatum)
            .ToListAsync();

        var eigeneBeitraege = beitraege
            .Where(b => b.UserId == user.Id)
            .ToList();

        var anzahlBeitraege = eigeneBeitraege.Count();

        var anzahlLikes = eigeneBeitraege
            .SelectMany(b => b.Likes)
            .Count();

        var anzahlDislikes = eigeneBeitraege
            .SelectMany(b => b.Dislikes)
            .Count();

        ViewBag.AnzahlBeitraege = anzahlBeitraege;
        ViewBag.AnzahlLikes = anzahlLikes;
        ViewBag.AnzahlDislikes = anzahlDislikes;

        return View(beitraege);
    }

    // GET: Beitrags/Auswertung
    [Authorize]
    public async Task<IActionResult> Auswertung()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }

        var beitraege = await _context.Beitrag
            .Where(b => b.UserId == user.Id)
            .Include(b => b.Likes)
            .Include(b => b.Dislikes)
            .ToListAsync();

        var anzahlBeitraege = beitraege.Count();

        var anzahlLikes = beitraege
            .SelectMany(b => b.Likes)
            .Count();

        var anzahlDislikes = beitraege
            .SelectMany(b => b.Dislikes)
            .Count();

        ViewBag.AnzahlBeitraege = anzahlBeitraege;
        ViewBag.AnzahlLikes = anzahlLikes;
        ViewBag.AnzahlDislikes = anzahlDislikes;

        return View();
    }

    // GET: BEITRAGS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BEITRAGS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Textinhalt")] Beitrag beitrag)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            beitrag.UserId = user.Id;
            beitrag.ErstellungsDatum = DateTime.Now;

            _context.Add(beitrag);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(beitrag);
    }

    // GET: BEITRAGS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var beitrag = await _context.Beitrag
            .FirstOrDefaultAsync(m => m.Id == id);

        if (beitrag == null)
        {
            return NotFound();
        }

        return View(beitrag);
    }

    // GET: BEITRAGS/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }

        var beitrag = await _context.Beitrag
            .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user.Id);

        if (beitrag == null)
        {
            return NotFound();
        }

        return View(beitrag);
    }


    // POST: BEITRAGS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Edit(
    int id,
    [Bind("Id,Textinhalt")] Beitrag beitrag)
    {
        if (id != beitrag.Id)
        {
            return NotFound();
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }

        var vorhandenerBeitrag = await _context.Beitrag
            .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user.Id);

        if (vorhandenerBeitrag == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            vorhandenerBeitrag.Textinhalt = beitrag.Textinhalt;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(beitrag);
    }


    // GET: BEITRAGS/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }

        var beitrag = await _context.Beitrag
            .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user.Id);

        if (beitrag == null)
        {
            return NotFound();
        }

        return View(beitrag);
    }


    // POST: BEITRAGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }

        var beitrag = await _context.Beitrag
            .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user.Id);

        if (beitrag == null)
        {
            return NotFound();
        }

        _context.Beitrag.Remove(beitrag);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

}