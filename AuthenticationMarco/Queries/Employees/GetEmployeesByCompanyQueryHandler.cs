using AuthenticationMarco.DTOs;
using AuthenticationMarco.Model;
using CQRSPattern.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMarco.Queries.Employees
{
    public class GetEmployeesByCompanyQueryHandler : IRequestHandler<GetEmployeesByCompanyQuery, IEnumerable<EmployeeDTO>>
    {
        private readonly AppDbContext _context;

        public GetEmployeesByCompanyQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDTO>> Handle(GetEmployeesByCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies
                .Include(c => c.Employees)
                .FirstOrDefaultAsync(c => c.CompanyId == request.CompanyId, cancellationToken);

            if (company == null)
            {
                return Enumerable.Empty<EmployeeDTO>();
            }

            return company.Employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                CompanyId = e.CompanyId,
                UserId = e.UserId,
                Username = e.Username
            }).ToList();
        }
    }

}
