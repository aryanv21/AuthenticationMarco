using AuthenticationMarco.DTOs;
using MediatR;

namespace AuthenticationMarco.Queries.Employees
{
    public class GetEmployeesQuery : IRequest<IEnumerable<EmployeeDTO>>{}

}
