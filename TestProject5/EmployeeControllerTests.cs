using AuthenticationMarco.Commands.Companies.Employee;
using AuthenticationMarco.Controllers;
using AuthenticationMarco.DTOs;
using AuthenticationMarco.Queries.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject5
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly EmployeeController _employeeController;

        public EmployeeControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetEmployees_ReturnsOkResult_WithListOfEmployees()
        {
            // arrange
            var employees = new List<EmployeeDTO>
            {
                new EmployeeDTO { EmployeeId = 1, Name = "Malay chaudhari", CompanyId = 1, UserId = 1, Username = "malacyc", Password = "password" },
                new EmployeeDTO { EmployeeId = 2, Name = "prabhuddha bhan", CompanyId = 1, UserId = 2, Username = "prabhudddhab", Password = "password" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetEmployeesQuery>(), default))
                .ReturnsAsync(employees);

            //act
            var result = await _employeeController.GetEmployees();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<EmployeeDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetEmployee_ReturnsOkResult_WithEmployee()
        {
            //arrange
            var employee = new EmployeeDTO { EmployeeId = 1, Name = "Malay chaudhari", CompanyId = 1, UserId = 1, Username = "MalayC", Password = "password" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetEmployeeByIdQuery>(), default))
                .ReturnsAsync(employee);

            // act
            var result = await _employeeController.GetEmployee(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<EmployeeDTO>(okResult.Value);
            Assert.Equal(1, returnValue.EmployeeId);
        }

        [Fact]
        public async Task GetEmployee_ReturnsNotFoundResult_WhenEmployeeDoesNotExist()
        {
            //Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetEmployeeByIdQuery>(), default))
                .ReturnsAsync((EmployeeDTO)null);

            //act
            var result = await _employeeController.GetEmployee(99);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostEmployee_ReturnsCreatedAtActionResult_WithEmployee()
        {
            //arrange
            var createEmployeeCommand = new CreateEmployeeCommand { Name = "Malay chauhdari", Username = "malayC", Password = "password", CompanyId = 1 };
            var employee = new EmployeeDTO { EmployeeId = 1, Name = "Malay chauhdari", CompanyId = 1, UserId = 1, Username = "malayc", Password = "password" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateEmployeeCommand>(), default))
                .ReturnsAsync(employee);

            //act
            var result = await _employeeController.PostEmployee(createEmployeeCommand);

            //assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<EmployeeDTO>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.EmployeeId);
            Assert.Equal("GetEmployee", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task PutEmployee_ReturnsNoContentResult_WhenUpdateIsSuccessful()
        {
            // Arrange
            var updateEmployeeCommand = new UpdateEmployeeCommand { EmployeeId = 1, Name = "Malay chauhdari", Username = "malayc", Password = "password", CompanyId = 1 };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateEmployeeCommand>(), default))
                .ReturnsAsync(Unit.Value);

            // act
            var result = await _employeeController.PutEmployee(1, updateEmployeeCommand);

            // assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PutEmployee_ReturnsBadRequestResult_WhenIdMismatch()
        {
            // arrange
            var updateEmployeeCommand = new UpdateEmployeeCommand { EmployeeId = 2, Name = "prabhudhha bhan", Username = "prabhuddhab", Password = "password", CompanyId = 1 };

            // act
            var result = await _employeeController.PutEmployee(1, updateEmployeeCommand);

            //assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsNoContentResult_WhenDeleteIsSuccessful()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteEmployeeCommand>(), default))
                .ReturnsAsync(Unit.Value);

            // act
            var result = await _employeeController.DeleteEmployee(1);

            //assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
