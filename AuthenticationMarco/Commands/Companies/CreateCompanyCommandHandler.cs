using AuthenticationMarco.DTOs;
using AuthenticationMarco.Model;
using CQRSPattern.Data;
using MediatR;

namespace AuthenticationMarco.Commands.Companies
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyDTO>
    {
        private readonly AppDbContext _context;

        public CreateCompanyCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyDTO> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                CompanyName = request.CompanyName
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync(cancellationToken);

            return new CompanyDTO
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName
            };
        }
    }
}
