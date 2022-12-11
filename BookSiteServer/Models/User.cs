using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Password { get; set; }

        public string? UserName { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Book> Library { get; set; }
    }
}
