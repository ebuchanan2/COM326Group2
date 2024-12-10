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
}
