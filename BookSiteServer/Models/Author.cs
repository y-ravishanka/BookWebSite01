using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class Author
    {
        [Key]
        public Guid AuthorId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<AuthorName>? AltName { get; set; }
    }
}
