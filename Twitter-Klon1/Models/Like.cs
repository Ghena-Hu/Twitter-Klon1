using Microsoft.AspNetCore.Identity;

namespace Twitter_Klon1.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int BeitragId { get; set; }
        public Beitrag? Beitrag { get; set; } = null;
        public string UserId { get; set; }

        public IdentityUser User { get; set; } = null;
    }
}
