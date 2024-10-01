using MediatR;

namespace AuthenticationMarco.Commands.Companies.Employee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
    }
}
