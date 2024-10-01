using AuthenticationMarco.Model;
using CQRSPattern.Data;
using MediatR;

namespace AuthenticationMarco.Commands.Companies
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly AppDbContext _context;

        public DeleteCompanyCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FindAsync(request.CompanyId);
            if (company == null)
            {
                throw new NotFoundException(nameof(Company), request.CompanyId);
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
