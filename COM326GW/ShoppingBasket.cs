using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW
{
    public class ShoppingBasket
    {
        private List<BasketItem> _items;

        public ShoppingBasket()
        {
            _items = new List<BasketItem>();
        }

        // Add an item to the customer shopping basket (logic in OnlineShop.cs)
        public void AddItem(Product product, int quantity)
        {
            var existingItem = _items.FirstOrDefault(item => item.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new BasketItem(product, quantity));
            }
        }

        // Remove an item from the customer shopping basket (logic in OnlineShop.cs)
        public void RemoveItem(int productId)
        {
            var itemToRemove = _items.FirstOrDefault(item => item.Product.ProductId == productId);
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
        }

        // Get the total cost of all products in the customer shopping basket
        public float GetTotalValue()
        {
            return _items.Sum(item => item.Product.ProductPrice * item.Quantity);
        }

        // Display the customer shopping basket
        public void DisplayBasket()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Your basket is empty.");
                return;
            }

            Console.WriteLine("Your Basket:");
            foreach (var item in _items)
            {
                Console.WriteLine($"{item.Product.ProductName} (ID: {item.Product.ProductId}) - {item.Quantity} x {item.Product.ProductPrice:C} = {item.Quantity * item.Product.ProductPrice:C}");
            }

            Console.WriteLine($"\nTotal Value: {GetTotalValue():C}");
        }
    }

    // Class for each item within the shopping basket
    class BasketItem
    {
        public Product Product { get; }
        public int Quantity { get; set; }

        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
