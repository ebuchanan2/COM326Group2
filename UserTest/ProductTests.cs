using COM326GW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopTests
{
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
}
