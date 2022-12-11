using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class Chapter
    {
        [Key]
        public Guid Id { get; set; }

        public int ChapterId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Book Book { get; set; }
    }
}