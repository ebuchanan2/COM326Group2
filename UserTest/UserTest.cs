using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_ShouldInitializeWithCorrectProperties()
        {
            // Arrange
            string username = "TestUser";
            string password = "Password123";
            string email = "testuser@example.com";
            string phone = "1234567890";
            string street = "123 Test Street";
            string city = "Test City";

            // Act
            User user = new User(username, password, email, phone, street, city);

            // Assert
            Assert.AreEqual(username, user.UserUsername);
            Assert.AreEqual(password, user.UserPassword);
            Assert.AreEqual(email, user.UserEmail);
            Assert.AreEqual(phone, user.UserPhone);
            Assert.AreEqual(street, user.UserAddressStreet);
            Assert.AreEqual(city, user.UserAddressCity);
        }

        [TestMethod]
        public void UserId_ShouldBeIncrementedForEachNewUser()
        {
            // Arrange
            User user1 = new User("User1", "Pass1", "user1@example.com", "1111111111", "Street1", "City1");
            User user2 = new User("User2", "Pass2", "user2@example.com", "2222222222", "Street2", "City2");

            // Act
            int firstUserId = user1.UserId;
            int secondUserId = user2.UserId;

            // Assert
            Assert.AreEqual(firstUserId + 1, secondUserId);
        }
    }
}