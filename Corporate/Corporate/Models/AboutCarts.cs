using System.ComponentModel.DataAnnotations;

namespace Corporate.Models
{
    public class AboutCarts
    {
        public int Id { get; set; }
        [Required]
        public string CartIcon { get; set; }
        [Required]
        public string CartTitle { get; set; }
        [Required]
        public string CartDescription { get; set; }
    }
}
