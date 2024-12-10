using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW.Tests
{
    [TestClass]
    public class ShoppingBasketTests
    {
        [TestMethod]
        public void AddItem_ShouldAddNewItem()
        {
            // Arrange
            var product = new Product("Test Product", "Test", 10.0f, 100, 2);
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
            var product = new Product("Test Product", "Test", 10.0f, 100, 2);
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
            Product product1 = new Product("Test Product", "Test", 10.0f, 100, 2);
            Product product2 = new Product("Test Product 2", "Test", 20.0f, 200, 1);
            ShoppingBasket basket = new ShoppingBasket();
            basket.AddItem(product1, 1);
            basket.AddItem(product2, 1);

            // Act
            OnlineShop.RemoveProductFromBasket()  // Remove Product 1

            // Assert
            var totalValue = basket.GetTotalValue();
            Assert.AreEqual(20.0f, totalValue);  // Only Product 2 is left
        }

        [TestMethod]
        public void GetTotalValue_ShouldCalculateCorrectTotal()
        {
            // Arrange
            var product1 = new Product("Test Product", "Test", 10.0f, 100, 2);
            var product2 = new Product("Test Product 2", "Test", 20.0f, 200, 1);
            var basket = new ShoppingBasket();
            basket.AddItem(product1, 2);  // 2 * 10.0f = 20.0f
            basket.AddItem(product2, 1);  // 1 * 20.0f = 20.0f

            // Act
            var totalValue = basket.GetTotalValue();

            // Assert
            Assert.AreEqual(40.0f, totalValue);  // 20.0f + 20.0f = 40.0f
        }
    }
}