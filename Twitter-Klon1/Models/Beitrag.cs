using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Twitter_Klon1.Models
{
    public class Beitrag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(420)]
        public string Textinhalt { get; set; }
        public DateTime ErstellungsDatum { get; set; } = DateTime.Now;

        public string? UserId { get; set; } //fremdschlüssel für user
        public IdentityUser? User { get; set; }=null;
        public ICollection<Like>? Likes { get; set; } = new List<Like>();
        public ICollection<Dislike> Dislikes { get; set; } = new List<Dislike>();
    }
}
