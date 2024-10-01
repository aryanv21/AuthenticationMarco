using AuthenticationMarco.DTOs;
using MediatR;

namespace AuthenticationMarco.Commands.Companies.Employee
{
    public class CreateEmployeeCommand : IRequest<EmployeeDTO>
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
