using AuthenticationMarco.DTOs;
using MediatR;

namespace AuthenticationMarco.Commands.Companies
{
    public class CreateCompanyCommand : IRequest<CompanyDTO>
    {
        public string CompanyName { get; set; }
    }
}
