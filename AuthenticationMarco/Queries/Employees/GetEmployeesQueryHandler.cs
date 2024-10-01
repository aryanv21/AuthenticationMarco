using AuthenticationMarco.DTOs;
using CQRSPattern.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMarco.Queries.Employees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDTO>>
    {
        private readonly AppDbContext _context;

        public GetEmployeesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.ToListAsync(cancellationToken);

            return employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                CompanyId = e.CompanyId,
                Username = e.Username,
                Password = e.Password
            }).ToList();
        }
    }
}
