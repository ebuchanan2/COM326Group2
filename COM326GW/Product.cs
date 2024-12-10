using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW
{
    public class Product
    {
        private static int _nextProductId = 1;

        private int _productId;
        private string _productName;
        private string _productDescription;
        private float _productPrice;
        private int _productStockQuantity;
        private int _productCategoryId;

        public Product(string productName, string productDescription, float productPrice, int productStockQuantity, int productCategoryId)
        {
            _productId = _nextProductId++;
            _productName = productName;
            _productDescription = productDescription;
            _productPrice = productPrice;
            _productStockQuantity = productStockQuantity;
            _productCategoryId = productCategoryId;
        }

        public int ProductId { get => _productId; set => _productId = value; }
        public string ProductName { get => _productName; set => _productName = value; }
        public string ProductDescription { get => _productDescription; set => _productDescription = value; }
        public float ProductPrice { get => _productPrice; set => _productPrice = value; }
        public int ProductStockQuantity { get => _productStockQuantity; set => _productStockQuantity = value; }
        public int ProductCategoryId { get => _productCategoryId; set => _productCategoryId = value; }

        // View a list of products
        public void ViewProducts(List<Product> products)
        {
            if (products.Count <= 0)
            {
                Console.WriteLine("No products available. Press any key to continue...");
                Console.ReadKey();
                return;
            }

            // Sort the products regarding category
            var sortedProducts = products.OrderBy(p => p.ProductCategoryId).ToList();

            Console.Clear();
            Console.WriteLine("Products ordered by Category ID:\n");

            // Display all products
            foreach (Product product in sortedProducts)
            {
                Console.WriteLine($"[{product.ProductId}]: {product.ProductName} (Category ID: {product.ProductCategoryId})");
            }

            Console.Write("\nTo view a product, enter the product id: ");
            string input = Console.ReadLine();

            // Parse the input
            if (int.TryParse(input, out int intInput))
            {
                var selectedProduct = sortedProducts.FirstOrDefault(p => p.ProductId == intInput);

                if (selectedProduct != null)
                {
                    Console.Clear();

                    selectedProduct.ViewProduct();
                }
                else
                {
                    Console.WriteLine("Product not found. Press any key to continue...");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Press any key to continue...");
            }

            Console.ReadKey();
        }

        // View a specified product
        public void ViewProduct()
        {
            int width = 15;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Global.Format("Name:", width)}{Global.LightGreen}{ProductName}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Description:", width)}{Global.LightGreen}{ProductDescription}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Price:", width)}{Global.LightGreen}{ProductPrice:C}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Stock:", width)}{Global.LightGreen}{ProductStockQuantity}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Category ID:", width)}{Global.LightGreen}{ProductCategoryId}{Global.Reset}\n");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
