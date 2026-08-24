using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter_Klon1.Data;
using Twitter_Klon1.Models;

public class DislikesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public DislikesController(
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Toggle(int beitragId)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return Unauthorized();
        }

        var vorhandenerDislike = await _context.Dislike
            .FirstOrDefaultAsync(d =>
                d.BeitragId == beitragId &&
                d.UserId == user.Id);

        if (vorhandenerDislike != null)
        {
            _context.Dislike.Remove(vorhandenerDislike);
        }
        else
        {
            var vorhandenerLike = await _context.Like
                .FirstOrDefaultAsync(l =>
                    l.BeitragId == beitragId &&
                    l.UserId == user.Id);

            if (vorhandenerLike != null)
            {
                _context.Like.Remove(vorhandenerLike);
            }

            var dislike = new Dislike
            {
                BeitragId = beitragId,
                UserId = user.Id
            };

            _context.Dislike.Add(dislike);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Beitrags");
    }
}


