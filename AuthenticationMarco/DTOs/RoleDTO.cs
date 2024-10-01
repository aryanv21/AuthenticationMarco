using System.ComponentModel.DataAnnotations;

namespace AuthenticationMarco.DTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }

    public class CreateRoleDTO
    {
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } = string.Empty;
    }

   
}
