using AuthenticationMarco.DTOs;
using MediatR;

namespace AuthenticationMarco.Queries.Companies
{
    public class GetCompaniesQuery : IRequest<List<CompanyDTO>>
    {
    }
}
