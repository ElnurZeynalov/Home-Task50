using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corporate.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Company { get; set; }
        [NotMapped,Required]
        public IFormFile Photo { get; set; }
    }
}
