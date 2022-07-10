using DiaryAPI.Controllers;
using DiaryAPI.Data;
using DiaryAPI.Models;
using DiaryAPI.UOW;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DiaryAPI.Tests
{
    public class UsersControllerTests
    {
        [Fact]
        public void GetUsers_Returns_The_Correct_Number_Of_Users()
        {
            //Arrange
            int count = 3;
            ApplicationDBContext context = new ApplicationDBContext();
            IUnitOfWork unitOfWork = new UnitOfWork(context);

            var dataStore = A.Fake<ApplicationDBContext>();
            var fakeUsers = A.CollectionOfDummy<User>(count).AsEnumerable();
            A.CallTo(() => dataStore.Users.Take(count)); 
            var usersController = new UsersController(unitOfWork);

            //Act
            var actionResult = usersController.GetUsers(count);

             
            //Assert
            var result = actionResult as OkObjectResult;
            var returnUsers = result.Value as IEnumerable<User>;
            Assert.Equal(count,returnUsers.Count());
        }
    }
}