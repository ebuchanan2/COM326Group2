using COM326GW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
