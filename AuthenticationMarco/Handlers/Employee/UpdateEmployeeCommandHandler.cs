using AuthenticationMarco.Commands.Companies.Employee;
using CQRSPattern.Data;
using MediatR;

namespace AuthenticationMarco.Handlers.Employee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly AppDbContext _context;

        public UpdateEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new NotFoundException("Employee not found");
            }

            employee.Name = request.Name;
            employee.CompanyId = request.CompanyId;
            employee.Username = request.Username;
            employee.Password = request.Password;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
