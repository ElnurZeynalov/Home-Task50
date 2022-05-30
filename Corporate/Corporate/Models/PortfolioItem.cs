using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corporate.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped,Required]
        public IFormFile Photo { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public PortfolioCategory Category { get; set; }
    }
}
