using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twitter_Klon1.Data;
using Twitter_Klon1.Models;

public class LikesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public LikesController(
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

        var vorhandenerLike = await _context.Like
            .FirstOrDefaultAsync(l =>
                l.BeitragId == beitragId &&
                l.UserId == user.Id);

        if (vorhandenerLike != null)
        {
            _context.Like.Remove(vorhandenerLike);
        }
        else
        {
            var vorhandenerDislike = await _context.Dislike
                .FirstOrDefaultAsync(d =>
                    d.BeitragId == beitragId &&
                    d.UserId == user.Id);

            if (vorhandenerDislike != null)
            {
                _context.Dislike.Remove(vorhandenerDislike);
            }

            var like = new Like
            {
                BeitragId = beitragId,
                UserId = user.Id
            };

            _context.Like.Add(like);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Beitrags");
    }

}