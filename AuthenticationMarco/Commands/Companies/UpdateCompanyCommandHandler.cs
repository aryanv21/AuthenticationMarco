using AuthenticationMarco.Model;
using CQRSPattern.Data;
using MediatR;

namespace AuthenticationMarco.Commands.Companies
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly AppDbContext _context;

        public UpdateCompanyCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FindAsync(request.CompanyId);
            if (company == null)
            {
                throw new NotFoundException(nameof(Company), request.CompanyId);
            }

            company.CompanyName = request.CompanyName;
            _context.Companies.Update(company);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
