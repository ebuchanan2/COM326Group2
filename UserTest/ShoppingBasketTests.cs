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
