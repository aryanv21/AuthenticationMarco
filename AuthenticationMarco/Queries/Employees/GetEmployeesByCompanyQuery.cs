using AuthenticationMarco.DTOs;
using MediatR;

namespace AuthenticationMarco.Queries.Employees
{
    public class GetEmployeesByCompanyQuery : IRequest<IEnumerable<EmployeeDTO>>
    {
        public int CompanyId { get; set; }

        public GetEmployeesByCompanyQuery(int companyId)
        {
            CompanyId = companyId;
        }
    }

}
