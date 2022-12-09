using System.ComponentModel.DataAnnotations;

namespace BookSiteServer.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        
        [Required]
        public string TagName { get; set; }

        public string? Description { get; set; }

    }
}
