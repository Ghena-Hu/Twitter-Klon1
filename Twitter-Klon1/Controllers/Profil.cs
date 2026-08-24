using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter_Klon1.Data;

namespace Twitter_Klon1.Controllers
{
    public class ProfilController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProfilController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string suche)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            var beitraege = _context.Beitrag
                .Where(b => b.UserId == user.Id);

            if (!string.IsNullOrWhiteSpace(suche))
            {
                beitraege = beitraege
                    .Where(b => b.Textinhalt.Contains(suche));
            }

            var liste = await beitraege
                .Include(b => b.Likes)
                .OrderByDescending(b => b.ErstellungsDatum)
                .ToListAsync();

            return View(liste);
        }
    }
}

