using System.ComponentModel.DataAnnotations;

namespace SRMS.Models
{
    public class AdminModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare ("Password")]
        public string Re_Password { get; set; }

    }
}
