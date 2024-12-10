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
}
