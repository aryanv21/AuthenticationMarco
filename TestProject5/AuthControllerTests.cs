//using AuthenticationMarco.DTOs;
//using AuthenticationMarco.Model;
//using Castle.Core.Configuration;
//using CQRSPattern.Controllers;
//using CQRSPattern.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject5
//{
//    public class AuthControllerTests
//    {
//        private readonly Mock<AppDbContext> _contextMock;
//        private readonly Mock<IConfiguration> _configurationMock;
//        private readonly AuthController _authController;

//        public AuthControllerTests()
//        {
//            _contextMock = new Mock<AppDbContext>();
//            _configurationMock = new Mock<IConfiguration>();
//            //_authController = new AuthController(_contextMock.Object, _configurationMock.Object);
//        }

//        [Fact]
//        public async Task Login_ReturnsOkResult_WithJwtToken()
//        {
//            // Arrange
//            var user = new User
//            {
//                UserName = "testuser",
//                Password = "password",
//                UserRoles = new List<UserRole>
//                {
//                    new UserRole { Role = new Role { RoleName = "Admin" } }
//                }
//            };

//            var users = new List<User> { user }.AsQueryable();
//            var mockSet = new Mock<DbSet<User>>();
//            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
//            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
//            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
//            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

//            _contextMock.Setup(c => c.Users).Returns(mockSet.Object);

//            //_configurationMock.Setup(c => c["Jwt:Key"]).Returns("YourVerySecujidofaodibhaih;oisdfgi;dafbadfbjhio;afgji;adfodfak;lhadfgioh34");
//            //_configurationMock.Setup(c => c["Jwt:Issuer"]).Returns("YourIssuer");
//            //_configurationMock.Setup(c => c["Jwt:Audience"]).Returns("YourAudience");

//            var loginRequest = new UserDTO { UserName = "testuser", Password = "password" };

//            // Act
//            var result = await _authController.Login(loginRequest);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var tokenResponse = Assert.IsType<Dictionary<string, string>>(okResult.Value);
//            Assert.True(tokenResponse.ContainsKey("token"));

//            var tokenHandler = new JwtSecurityTokenHandler();
//            var token = tokenHandler.ReadJwtToken(tokenResponse["token"]);
//            Assert.Equal("testuser", token.Subject);
//            Assert.Contains(token.Claims, c => c.Type == ClaimTypes.Role && c.Value == "Admin");
//        }

//        [Fact]
//        public async Task Login_ReturnsUnauthorized_WhenInvalidCredentials()
//        {
//            // Arrange
//            var users = new List<User>().AsQueryable();
//            var mockSet = new Mock<DbSet<User>>();
//            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
//            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
//            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
//            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

//            _contextMock.Setup(c => c.Users).Returns(mockSet.Object);

//            var loginRequest = new UserDTO { UserName = "invaliduser", Password = "invalidpassword" };

//            // Act
//            var result = await _authController.Login(loginRequest);

//            // Assert
//            Assert.IsType<UnauthorizedResult>(result);
//        }
//    }
//}
