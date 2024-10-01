using System.ComponentModel.DataAnnotations;

namespace AuthenticationMarco.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
