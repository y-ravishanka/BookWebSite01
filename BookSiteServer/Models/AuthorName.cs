using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class AuthorName
    {
        [Key]
        public int AltNameId { get; set; }

        public string Name { get; set; }
    }
}