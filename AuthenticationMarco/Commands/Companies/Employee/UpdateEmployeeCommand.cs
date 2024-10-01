using MediatR;

namespace AuthenticationMarco.Commands.Companies.Employee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
