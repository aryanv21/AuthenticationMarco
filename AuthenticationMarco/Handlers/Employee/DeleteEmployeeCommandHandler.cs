using AuthenticationMarco.Commands.Companies.Employee;
using CQRSPattern.Data;
using MediatR;

namespace AuthenticationMarco.Handlers.Employee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly AppDbContext _context;

        public DeleteEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new NotFoundException("Employee not found");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
