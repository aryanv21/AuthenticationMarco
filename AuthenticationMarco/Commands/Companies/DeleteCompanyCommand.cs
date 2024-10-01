using MediatR;

namespace AuthenticationMarco.Commands.Companies
{
    public class DeleteCompanyCommand : IRequest
    {
        public int CompanyId { get; set; }
    }

}
