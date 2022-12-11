using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
