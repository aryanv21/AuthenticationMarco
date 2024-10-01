using System.ComponentModel.DataAnnotations;

namespace AuthenticationMarco.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class CreateEmployeeDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public int CompanyId { get; set; }
    }

    public class UpdateEmployeeDTO
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public int CompanyId { get; set; } 
    }


}
