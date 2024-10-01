using System.ComponentModel.DataAnnotations;

namespace AuthenticationMarco.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
    }

    public class CreateUserDTO
    {
        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
    }

   
}
