using System.ComponentModel.DataAnnotations;

namespace AuthenticationMarco.DTOs
{
    public class UserRoleDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class CreateUserRoleDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }
    }

    
}
