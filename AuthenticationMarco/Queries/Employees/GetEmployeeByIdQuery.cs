using AuthenticationMarco.DTOs;
using MediatR;

namespace AuthenticationMarco.Queries.Employees
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDTO>
    {
        public int EmployeeId { get; set; }
    }
}
