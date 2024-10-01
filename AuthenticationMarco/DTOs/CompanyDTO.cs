using System.ComponentModel.DataAnnotations;

namespace AuthenticationMarco.DTOs
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
    }

    public class CreateCompanyDTO
    {
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;
    }

    public class UpdateCompanyDTO
    {
        [Required]
        [StringLength(100)]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
    }
}
