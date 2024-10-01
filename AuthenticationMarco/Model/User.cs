using System.ComponentModel.DataAnnotations;

namespace AuthenticationMarco.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
