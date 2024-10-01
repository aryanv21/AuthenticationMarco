using AuthenticationMarco.Commands.Companies;
using AuthenticationMarco.DTOs;
using AuthenticationMarco.Queries.Companies;
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
    public class CompanyControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CompanyController _controller;

        public CompanyControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CompanyController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetCompanies_ReturnsOkResult_WithListOfCompanies()
        {
            // arrange
            var companies = new List<CompanyDTO> { new CompanyDTO { CompanyId = 1, CompanyName = "cyabge" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCompaniesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(companies);

            // act
            var result = await _controller.GetCompanies();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<CompanyDTO>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetCompany_ReturnsOkResult_WithCompany()
        {
            // arrange
            var company = new CompanyDTO { CompanyId = 1, CompanyName = "cybage" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCompanyByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(company);

            // Act
            var result = await _controller.GetCompany(1);

            //assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<CompanyDTO>(okResult.Value);
            Assert.Equal(1, returnValue.CompanyId);
        }

        [Fact]
        public async Task GetCompany_ReturnsNotFound_WhenCompanyNotExists()
        {
            //Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCompanyByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((CompanyDTO)null);

            //act
            var result = await _controller.GetCompany(1);

            // assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetEmployeesByCompany_ReturnsOkResult_WithListOfEmployees()
        {
            // Arrange
            var employees = new List<EmployeeDTO> { new EmployeeDTO { EmployeeId = 1, Name = "Employee1" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetEmployeesByCompanyQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(employees);

            //act
            var result = await _controller.GetEmployeesByCompany(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<EmployeeDTO>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task PostCompany_ReturnsCreatedAtAction_WithCompany()
        {
            //arrange
            var company = new CompanyDTO { CompanyId = 1, CompanyName = "cybage" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCompanyCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(company);

            //act
            var result = await _controller.PostCompany(new CreateCompanyCommand());

            //assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<CompanyDTO>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.CompanyId);
        }

        [Fact]
        public async Task PutCompany_ReturnsNoContent()
        {
            //arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateCompanyCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Unit.Value);

            //act
            var result = await _controller.PutCompany(1, new UpdateCompanyCommand { CompanyId = 1 });

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCompany_ReturnsNoContent()
        {
            //arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCompanyCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Unit.Value);

            //act
            var result = await _controller.DeleteCompany(1);

            // assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
