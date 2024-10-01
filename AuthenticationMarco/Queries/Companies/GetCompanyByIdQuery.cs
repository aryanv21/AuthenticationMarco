using AuthenticationMarco.DTOs;
using MediatR;

namespace AuthenticationMarco.Queries.Companies
{
    public class GetCompanyByIdQuery : IRequest<CompanyDTO>
    {
        public int CompanyId { get; set; }
    }

}
