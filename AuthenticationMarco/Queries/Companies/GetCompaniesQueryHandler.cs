using AuthenticationMarco.DTOs;
using CQRSPattern.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMarco.Queries.Companies
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, List<CompanyDTO>>
    {
        private readonly AppDbContext _context;

        public GetCompaniesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyDTO>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _context.Companies.ToListAsync(cancellationToken);
            return companies.Select(c => new CompanyDTO
            {
                CompanyId = c.CompanyId,
                CompanyName = c.CompanyName
            }).ToList();
        }
    }

}
