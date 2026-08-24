using Microsoft.AspNetCore.Identity;

namespace Twitter_Klon1.Models
{
    public class Dislike
    {
        public int Id { get; set; }

        public int BeitragId { get; set; }
        public Beitrag? Beitrag { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; } = null!;
    }
}


