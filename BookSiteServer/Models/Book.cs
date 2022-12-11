using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public string ShortTitle { get; set; }

        public string Description { get; set; }

        public ICollection<Tag> Tag { get; set; }

        public ICollection<BookTitle> AltTitle { get; set; }

        public string Status { get; set; }

        public int ChaptersNum { get; set; }

        public int Views { get; set; }

        public int Readers { get; set; }

        public int Rate { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Chapter> Chapters { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
