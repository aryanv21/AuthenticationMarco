using AuthenticationMarco.Commands.Companies.Employee;
using AuthenticationMarco.DTOs;
using AuthenticationMarco.Model;
using CQRSPattern.Data;
using MediatR;
using AuthenticationMarco.Model;

namespace AuthenticationMarco.Handlers.Employee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDTO>
    {
        private readonly AppDbContext _context;

        public CreateEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Model.Employee
            {
                Name = request.Name,
                CompanyId = request.CompanyId,
                UserId = request.UserId,
                Username = request.Username,
                Password = request.Password
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

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
