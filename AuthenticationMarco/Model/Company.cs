using System.ComponentModel.DataAnnotations;

namespace AuthenticationMarco.Model
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
