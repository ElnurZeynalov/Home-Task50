using System.ComponentModel.DataAnnotations;

namespace Corporate.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(30)]
        public string Email { get; set; }
        [Required,MaxLength(150)]
        public string Message { get; set; }
    }
}
