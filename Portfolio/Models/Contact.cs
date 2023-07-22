using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Contact
    {
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
