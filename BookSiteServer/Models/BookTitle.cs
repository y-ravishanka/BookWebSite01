using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class BookTitle
    {
        [Key]
        public int AltTitleId { get; set; }

        public string Title { get; set; }

        public Book Book { get; set; }
    }
}