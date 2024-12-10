using COM326GW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Customer_Constructor_ShouldInitializeCustomer()
        {
            // Arrange
            string userUsername = "john_doe";
            string userPassword = "password123";
            string userEmail = "john@example.com";
            string userPhone = "123-456-7890";
            string userAddressStreet = "123 Elm St";
            string userAddressCity = "Somewhere";
            string userStatus = "Active";
            string userRole = "Admin";

            // Act
            Customer customer = new Customer(userUsername, userPassword, userEmail, userPhone, userAddressStreet, userAddressCity, userStatus, userRole);

            // Assert
            Assert.AreEqual(userUsername, customer.UserUsername);
            Assert.AreEqual(userPassword, customer.UserPassword);
            Assert.AreEqual(userEmail, customer.UserEmail);
            Assert.AreEqual(userPhone, customer.UserPhone);
            Assert.AreEqual(userAddressStreet, customer.UserAddressStreet);
            Assert.AreEqual(userAddressCity, customer.UserAddressCity);
            Assert.AreEqual(userStatus, customer.UserStatus);
            Assert.AreEqual(userRole, customer.UserRole);
        }

        [TestMethod]
        public void ViewCustomer_ShouldDisplayFormattedCustomerDetails()
        {
            // Arrange
            string userUsername = "john_doe";
            string userPassword = "password123";
            string userEmail = "john@example.com";
            string userPhone = "123-456-7890";
            string userAddressStreet = "123 Elm St";
            string userAddressCity = "Somewhere";
            string userStatus = "Active";
            string userRole = "Admin";

            var customer = new Customer(userUsername, userPassword, userEmail, userPhone, userAddressStreet, userAddressCity, userStatus, userRole);

            // Redirect console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                customer.ViewCustomer();

                string output = sw.ToString();

                // Assert
                Assert.IsTrue(output.Contains(userUsername));
                Assert.IsTrue(output.Contains(userPassword));
                Assert.IsTrue(output.Contains(userEmail));
                Assert.IsTrue(output.Contains(userPhone));
                Assert.IsTrue(output.Contains(userAddressStreet));
                Assert.IsTrue(output.Contains(userAddressCity));
                Assert.IsTrue(output.Contains(userStatus));
                Assert.IsTrue(output.Contains(userRole));
            }
        }

        [TestMethod]
        public void ViewCustomer_ShouldDisplayRedForInactiveStatus()
        {
            // Arrange
            string userUsername = "john_doe";
            string userPassword = "password123";
            string userEmail = "john@example.com";
            string userPhone = "123-456-7890";
            string userAddressStreet = "123 Elm St";
            string userAddressCity = "Somewhere";
            string userStatus = "Inactive"; // Inactive status
            string userRole = "Admin";

            var customer = new Customer(userUsername, userPassword, userEmail, userPhone, userAddressStreet, userAddressCity, userStatus, userRole);

            // Redirect console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                customer.ViewCustomer();

                string output = sw.ToString();

                // Assert that the status is printed with the red color
                Assert.IsTrue(output.Contains(Global.LightRed));
                Assert.IsTrue(output.Contains(userStatus));
            }
        }
    }
}