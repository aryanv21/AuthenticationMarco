using MediatR;

namespace AuthenticationMarco.Commands.Companies
{
    public class UpdateCompanyCommand : IRequest
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

}
