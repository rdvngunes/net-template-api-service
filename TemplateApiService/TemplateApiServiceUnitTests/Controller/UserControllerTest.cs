using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TemplateApiService.BusinessObject.UsersBO;
using TemplateApiService.Common.Extensions;
using TemplateApiService.Common.RestClient;
using TemplateApiService.Controllers;
using TemplateApiService.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TemplateApiService.Common.Enums;

namespace TemplateApiServiceUnitTests.Controller
{
    public class UserControllerTest
    {
        private readonly UserController UserController;

        private Mock<ILogger<UserController>> mockLogger;
        private Mock<IUsersBO> mockService;

        public UserControllerTest()
        {
            this.mockLogger = new Mock<ILogger<UserController>>();
            this.mockService = new Mock<IUsersBO>();

            UserController = new UserController(
            this.mockLogger.Object,
            this.mockService.Object);
            TypeAdapterConfig<ApiRestResponseResult, ObjectResult>.NewConfig().PreserveReference(true).MapWith(map => map.ToObjectResult(), applySettings: true);
        }

       
        [Fact]
        public async Task PostUserharacteristics_Should_Save_User_When_Method_Call()
        {
            // Arrange
            UsersViewModel UsersViewModel = new UsersViewModel();

            var response = new ApiRestResponseResult();
            response.StatusCode = StatusCodes.Status201Created;
            // Act
            mockService.Setup(x => x.CreateUsers(UsersViewModel))
                .Returns(Task.FromResult<IActionResult>(response.Adapt<ObjectResult>())).Verifiable();

            var result = await UserController.PostUserharacteristics(UsersViewModel);
            // Assert
            var objectResult = (ObjectResult)result;
            var serviceResponse = (ApiRestResponseResult)objectResult.Value;
            Assert.NotNull(objectResult);
            Assert.Equal(201, objectResult.StatusCode);
            Assert.IsAssignableFrom<ApiRestResponseResult>(objectResult.Value);
        }

        [Fact]
        public async Task GetCustomUser_Should_Return_User_Details_When_Method_Call()
        {
            // Arrange
            string userId = "c8f699c9-07e1-40e1-bb5e-951605fb4332";

            var user = new UsersViewModel()
            {
            };

            var response = new ApiRestResponseResult();
            response.Status = EnumHttpStatusCode.success;
            response.Data = user;
            // Act
            mockService.Setup(x => x.GetUser(new Guid(userId)))
                .Returns(Task.FromResult<IActionResult>(response.Adapt<ObjectResult>())).Verifiable();

            var result = await UserController.GetUser(userId);
            // Assert
            var objectResult = (ObjectResult)result;
            var serviceResponse = (ApiRestResponseResult)objectResult.Value;
            var userresponse = (UsersViewModel)serviceResponse.Data;
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
            Assert.IsAssignableFrom<ApiRestResponseResult>(objectResult.Value);
        }
    }
}