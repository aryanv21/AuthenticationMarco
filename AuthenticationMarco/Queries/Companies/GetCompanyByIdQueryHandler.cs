using AuthenticationMarco.DTOs;
using AuthenticationMarco.Model;
using CQRSPattern.Data;
using MediatR;

namespace AuthenticationMarco.Queries.Companies
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDTO>
    {
        private readonly AppDbContext _context;

        public GetCompanyByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyDTO> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FindAsync(request.CompanyId);
            if (company == null)
            {
                throw new NotFoundException(nameof(Company), request.CompanyId);
            }

            return new CompanyDTO
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName
            };
        }
    }

}
