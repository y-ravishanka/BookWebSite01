using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; }

        public int Rate { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public User User { get; set; }

        public Book Book { get; set; }
    }
}