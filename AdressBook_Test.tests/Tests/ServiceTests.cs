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
            var result = userService.PrintAllUser();
            
            // Assert
            Assert.Empty(collection: result);
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
