using COM326GW;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopTests
{
    [TestClass]
    public class Tests
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
#

              
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

    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Admin_Constructor_ShouldInitializeAdmin()
        {
            // Arrange
            string userUsername = "admin_user";
            string userPassword = "adminpass";
            string userEmail = "admin@example.com";
            string userPhone = "987-654-3210";
            string userAddressStreet = "456 Admin St";
            string userAddressCity = "Admin City";
            DateTime adminLastLogin = new DateTime(2024, 12, 1);

            // Act
            Admin admin = new Admin(userUsername, userPassword, userEmail, userPhone, userAddressStreet, userAddressCity, adminLastLogin);

            // Assert
            Assert.AreEqual(userUsername, admin.UserUsername);
            Assert.AreEqual(userPassword, admin.UserPassword);
            Assert.AreEqual(userEmail, admin.UserEmail);
            Assert.AreEqual(userPhone, admin.UserPhone);
            Assert.AreEqual(userAddressStreet, admin.UserAddressStreet);
            Assert.AreEqual(userAddressCity, admin.UserAddressCity);
            Assert.AreEqual(adminLastLogin, admin.AdminLastLogin);
        }

        [TestMethod]
        public void ViewAdmin_ShouldDisplayAdminDetails()
        {
            // Arrange
            string userUsername = "admin_user";
            string userPassword = "adminpass";
            string userEmail = "admin@example.com";
            string userPhone = "987-654-3210";
            string userAddressStreet = "456 Admin St";
            string userAddressCity = "Admin City";
            DateTime adminLastLogin = DateTime.Now;
            Admin admin = new Admin(userUsername, userPassword, userEmail, userPhone, userAddressStreet, userAddressCity, adminLastLogin);

            // Redirect console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                admin.ViewAdmin();

                string output = sw.ToString();

                // Assert
                Assert.IsTrue(output.Contains(userUsername));
                Assert.IsTrue(output.Contains(userPassword));
                Assert.IsTrue(output.Contains(userEmail));
                Assert.IsTrue(output.Contains(userPhone));
                Assert.IsTrue(output.Contains(userAddressStreet));
                Assert.IsTrue(output.Contains(userAddressCity));
                //Assert.IsTrue(output.Contains(adminLastLogin.ToString("dd-MM-yyyy"))); // Validate last login date format
            }
        }

        [TestMethod]
        public void AdminLastLogin_ShouldBeUpdatedCorrectly()
        {
            // Arrange
            string userUsername = "admin_user";
            string userPassword = "adminpass";
            string userEmail = "admin@example.com";
            string userPhone = "987-654-3210";
            string userAddressStreet = "456 Admin St";
            string userAddressCity = "Admin City";
            DateTime initialLastLogin = new DateTime(2024, 12, 1);
            Admin admin = new Admin(userUsername, userPassword, userEmail, userPhone, userAddressStreet, userAddressCity, initialLastLogin);

            // Act
            DateTime newLastLogin = new DateTime(2024, 12, 8);
            admin.AdminLastLogin = newLastLogin;

            // Assert
            Assert.AreEqual(newLastLogin, admin.AdminLastLogin);
        }
    }

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

    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Category_Constructor_ShouldInitializeCategory()
        {
            // Arrange
            string categoryName = "Electronics";
            string categoryDescription = "Devices and gadgets";

            // Act
            Category category = new Category(categoryName, categoryDescription);

            // Assert
            Assert.AreEqual(categoryName, category.CategoryName);
            Assert.AreEqual(categoryDescription, category.CategoryDescription);
        }

        [TestMethod]
        public void ViewCategory_ShouldDisplayCategoryDetails()
        {
            // Arrange
            string categoryName = "Electronics";
            string categoryDescription = "Devices and gadgets";
            Category category = new Category(categoryName, categoryDescription);

            // Redirect console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                category.ViewCategory();

                string output = sw.ToString();

                // Assert
                Assert.IsTrue(output.Contains(categoryName));
                Assert.IsTrue(output.Contains(categoryDescription));
            }
        }
    }

    [TestClass]
    public class GlobalTests
    {
        [TestMethod]
        public void Format_ShouldPadRightString_WhenWidthIsGreaterThanLabelLength()
        {
            // Arrange
            string label = "Test";
            int width = 10;

            // Act
            string result = Global.Format(label, width);

            // Assert
            Assert.AreEqual("Test      ", result); // Expected padding
        }

        [TestMethod]
        public void Format_ShouldNotPadString_WhenWidthIsLessThanOrEqualToLabelLength()
        {
            // Arrange
            string label = "Test";
            int width = 3;

            // Act
            string result = Global.Format(label, width);

            // Assert
            Assert.AreEqual("Test", result); // No padding if width is less than or equal to label length
        }

        [TestMethod]
        public void Format_ShouldPadStringCorrectly_WhenWidthIsExact()
        {
            // Arrange
            string label = "Test";
            int width = 4;

            // Act
            string result = Global.Format(label, width);

            // Assert
            Assert.AreEqual("Test", result); // No padding needed, width is exactly the length of label
        }
    }

    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ProductConstructor_ShouldInitializeProperties()
        {
            // Arrange
            string productName = "Product 1";
            string productDescription = "Description of Product 1";
            float productPrice = 99.99f;
            int productStockQuantity = 10;
            int productCategoryId = 1;

            // Act
            var product = new Product(productName, productDescription, productPrice, productStockQuantity, productCategoryId);

            // Assert
            Assert.AreEqual(productName, product.ProductName);
            Assert.AreEqual(productDescription, product.ProductDescription);
            Assert.AreEqual(productPrice, product.ProductPrice);
            Assert.AreEqual(productStockQuantity, product.ProductStockQuantity);
            Assert.AreEqual(productCategoryId, product.ProductCategoryId);
        }
    }

    [TestClass]
    public class ShoppingBasketTests
    {
        [TestMethod]
        public void AddItem_ShouldAddNewItem()
        {
            // Arrange
            var product = new Product("Product 1", "Description of Product 1", 10f, 10, 1);
            var basket = new ShoppingBasket();

            // Act
            basket.AddItem(product, 2);

            // Assert
            var totalValue = basket.GetTotalValue();
            Assert.AreEqual(20.0f, totalValue);
        }

        [TestMethod]
        public void AddItem_ShouldUpdateExistingItemQuantity()
        {
            // Arrange
            var product = new Product("Product 1", "Description of Product 1", 10f, 10, 1);
            var basket = new ShoppingBasket();
            basket.AddItem(product, 2);

            // Act
            basket.AddItem(product, 3);  // Adding more of the same product

            // Assert
            var totalValue = basket.GetTotalValue();
            Assert.AreEqual(50.0f, totalValue);  // 5 * 10.0f = 50.0f
        }

        [TestMethod]
        public void RemoveItem_ShouldRemoveItemFromBasket()
        {
            // Arrange
            var product = new Product("Product 1", "Description of Product 1", 10f, 10, 1);
            var product2 = new Product("Product 2", "Description of Product 2", 20f, 10, 1);
            var basket = new ShoppingBasket();
            basket.AddItem(product, 2);
            basket.AddItem(product2, 1);

            // Act
            basket.RemoveItem(1);  // Remove Product 1

            // Assert
            var totalValue = basket.GetTotalValue();
            Assert.AreEqual(20.0f, totalValue);  // Only Product 2 is left
        }

        [TestMethod]
        public void GetTotalValue_ShouldCalculateCorrectTotal()
        {
            // Arrange
            var product = new Product("Product 1", "Description of Product 1", 10f, 10, 1);
            var product2 = new Product("Product 2", "Description of Product 2", 20f, 10, 1);
            var basket = new ShoppingBasket();
            basket.AddItem(product, 2);  // 2 * 10.0f = 20.0f
            basket.AddItem(product2, 1);  // 1 * 20.0f = 20.0f

            // Act
            var totalValue = basket.GetTotalValue();

            // Assert
            Assert.AreEqual(40.0f, totalValue);  // 20.0f + 20.0f = 40.0f
        }
    }
}
