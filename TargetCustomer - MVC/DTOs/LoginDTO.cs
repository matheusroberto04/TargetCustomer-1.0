using System.ComponentModel.DataAnnotations;

namespace TargetCustomer___MVC.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string SenhaHash { get; set; }
    }
}
