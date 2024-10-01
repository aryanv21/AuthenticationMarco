using AuthenticationMarco.DTOs;
using AuthenticationMarco.Queries.Employees;
using CQRSPattern.Data;
using MediatR;

namespace AuthenticationMarco.Handlers.Employee
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly AppDbContext _context;

        public GetEmployeeByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                return null;
            }

            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                CompanyId = employee.CompanyId,
                Username = employee.Username,
                Password = employee.Password
            };
        }
    }
}
