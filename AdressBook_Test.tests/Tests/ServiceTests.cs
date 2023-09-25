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
        [Fact]
        public void UserService_PrintAllUser_Should_Return0IfListIsEmpty()
        {
            // Arrange
            UserService userService = new UserService();

            // Act
            var restult = userService.PrintAllUser();
            
            // Assert
            Assert.Empty(restult);
        }

        [Fact]
        public void UserService_PrintAllUser_Should_ReturnTrueIfListIsNotEmpty()
        {
            // Arrange
            User user = new User();
            UserService userService = new UserService();

            // Act
            userService.AddUser(user);
            var restult = userService.PrintAllUser();

            // Assert
            Assert.NotEmpty(restult);
        }
    }
}
