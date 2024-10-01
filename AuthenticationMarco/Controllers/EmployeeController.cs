using AuthenticationMarco.Commands.Companies.Employee;
using AuthenticationMarco.DTOs;
using AuthenticationMarco.Queries.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationMarco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "AdminOnly")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _mediator.Send(new GetEmployeesQuery());
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { EmployeeId = id });
            return employee != null ? Ok(employee) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(CreateEmployeeCommand command)
        {
            var employee = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, UpdateEmployeeCommand command)
        {
            if (id != command.EmployeeId)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = id });
            return NoContent();
        }
    }
}

