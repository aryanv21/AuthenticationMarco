using AuthenticationMarco.Commands.Companies;
using AuthenticationMarco.DTOs;
using AuthenticationMarco.Queries.Companies;
using AuthenticationMarco.Queries.Employees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "AdminOnly")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
    {
        var companies = await _mediator.Send(new GetCompaniesQuery());
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
    {
        var company = await _mediator.Send(new GetCompanyByIdQuery { CompanyId = id });
        return company != null ? Ok(company) : NotFound();
    }

    [HttpGet("{companyId}/employees")]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByCompany(int companyId)
    {
        try
        {
            // Validate the companyId
            if (companyId <= 0)
            {
                return BadRequest("Invalid Company ID.");
            }

            var query = new GetEmployeesByCompanyQuery(companyId);
            var employees = await _mediator.Send(query);

            // Handle the case when no employees are found
            if (employees == null || !employees.Any())
            {
                return NotFound($"No employees found for company ID {companyId}.");
            }

            return Ok(employees);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<CompanyDTO>> PostCompany(CreateCompanyCommand command)
    {
        var company = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCompany), new { id = company.CompanyId }, company);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCompany(int id, UpdateCompanyCommand command)
    {
        if (id != command.CompanyId)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        await _mediator.Send(new DeleteCompanyCommand { CompanyId = id });
        return NoContent();
    }

}
