using AdressBook.Models;
using AdressBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook_Test.tests.Tests
{
    public class ServiceTests
    {
        User user = new User();
        UserService userService = new UserService();

        [Fact]
        public void UserService_PrintAllUser_Should_Return0IfListIsEmpty()
        {
            // Arrange

            // Act
            var restult = userService.PrintAllUser();
            
            // Assert
            Assert.Empty(restult);
        }

        [Fact]
        public void UserService_PrintAllUser_Should_ReturnTrueIfListIsNotEmpty()
        {
            // Arrange
            // UserService userService = new UserService();

            // Act
            userService.AddUser(user);
            var restult = userService.PrintAllUser();

            // Assert
            Assert.NotEmpty(restult);
        }

        [Fact]
        void UserService_DeleteUser_ShouldReturnNotEqualWhenDeleted()
        {
            // Arrange

            // Act
            int numInList = userService.AddUser(user);
            int numAfterDelete = userService.DeleteUser(user);
            // Assert

            Assert.NotEqual(numInList, numAfterDelete);
        }

        [Fact]
        void UserService_DeleteUser_ShouldReturnEqualWhenWrongUserDeleted()
        {
            // Arrange
            var user1 = new User();
            // Act
            int numInList = userService.AddUser(user);
            int numAfterDelete = userService.DeleteUser(user1);
            // numAfterDelete = userService.DeleteUser(user);
            
            // Assert
            Assert.Equal(numInList, numAfterDelete);
        }

        [Fact]
        void UserService_ReturnOneUser_ShouldReturnEqualIfUserIsInList()
        {
            // Arrange
            var user = new User();
            user.FirstName = "Test";
            userService.AddUser(user);
            // Act
            var returnAnswer = userService.PrintOneUser("test");

            // Assert
            Assert.Equal("Test", returnAnswer.FirstName);
        }
        
        [Fact]
        void UserService_ReturnOneUser_ShouldReturnEqualIfUserIsNotInList()
        {
            // Arrange
            var user = new User();
            user.FirstName = "Test";
            userService.AddUser(user);
            // Act
            var returnAnswer = userService.PrintOneUser("test");

            // Assert
            Assert.Equal("Test", returnAnswer.FirstName);
        }
    }
}
