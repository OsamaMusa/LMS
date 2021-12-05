using API.Controllers;
using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject_LMS
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> MockUserService;

        public UserControllerTest()
        {
            MockUserService = new Mock<IUserService>();
        }
        [Fact]
        public void GetUserByID_UserObject_UserExist()
        {
            //Arrange 
           
            MockUserService.Setup(x => x.getUserByID(It.IsAny<long>()).Result)
            .Returns(Getuser());
            var controller = new UsersController(MockUserService.Object);
            //Act
            var actionResult = controller.getUser(1);
           

            //Assert
           
            Assert.Equal(1, actionResult.Result.ID);
           // Assert.NotNull(actionResult);


        }

        [Fact]
        public void GetUserByID_UserObject_UserNotExist()
        {

            //Arrange 

            MockUserService.Setup(x => x.getUserByID(It.IsAny<long>()))
            .Returns((Task<UserVM>)null);
            var controller = new UsersController(MockUserService.Object);
            //Act
            var actionResult = controller.getUser(1);


            //Assert

            Assert.Null(actionResult);
            // Assert.NotNull(actionResult);
        }


        private UserVM Getuser()
        {
            return new UserVM() { ID = 1 };
        }
    }
}