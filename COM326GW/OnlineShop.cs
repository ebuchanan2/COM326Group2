using System;
using System.Collections.Generic;
using System.Linq;

namespace COM326GW
{
    // Class that represents the Online Shop application
    public class OnlineShop
    {
        private Customer _currentCustomer;  // Holds the current logged-in customer
        private Admin _currentAdmin;  // Holds the current logged-in admin
        private readonly ShoppingBasket _shoppingBasket = new();  // The shopping basket for the user

        private List<Customer> _customers = new();  // List to store customer information
        private List<Admin> _admins = new();  // List to store admin information
        private List<Category> _categories = new();  // List to store product categories
        private List<Product> _products = new();  // List to store products available in the shop

        private Dictionary<string, Customer> _customerDictionary = new();  // Dictionary for fast access to customers by their usernames
        private Dictionary<string, Admin> _adminDictionary = new();  // Dictionary for fast access to admins by their usernames
        private Dictionary<string, Category> _categoryDictionary = new();  // Dictionary for fast access to categories by their names
        private Dictionary<string, Product> _productDictionary = new();  // Dictionary for fast access to products by their names

        // Main method that starts the program
        public void Begin()
        {
            Initialize();  // Initialize the data
            Login();  // Start the login process for the user
        }

        // Method to initialize the customers, admins, categories, and products
        private void Initialize()
        {
            InitializeCustomers();  // Initializes the customer list
            InitializeAdmins();  // Initializes the admin list
            InitializeCategories();  // Initializes the category list
            InitializeProducts();  // Initializes the product list
        }

        // Initializes customer data
        private void InitializeCustomers()
        {
            _customers = new List<Customer>
            {
                new("Customer1", "Password1", "customer1@example.com", "123456789", "Example Street", "Example City", "Active", "Customer"),
                new("Customer2", "Password2", "customer2@example.com", "123456789", "Example Street", "Example City", "Active", "Customer"),
                new("Customer3", "Password3", "customer3@example.com", "123456789", "Example Street", "Example City", "Active", "Customer")
            };
            _customerDictionary = _customers.ToDictionary(c => c.UserUsername);  // Store customers in a dictionary for easy lookup by username
        }

        // Initializes admin data
        private void InitializeAdmins()
        {
            _admins = new List<Admin>
            {
                new("Admin1", "Password1", "admin1@example.com", "123456789", "Example Street", "Example City", DateTime.Now),
                new("Admin2", "Password2", "admin2@example.com", "123456789", "Example Street", "Example City", DateTime.Now),
                new("Admin3", "Password3", "admin3@example.com", "123456789", "Example Street", "Example City", DateTime.Now)
            };
            _adminDictionary = _admins.ToDictionary(a => a.UserUsername);  // Store admins in a dictionary for easy lookup by username
        }

        // Initializes product categories
        private void InitializeCategories()
        {
            _categories = new List<Category>
            {
                new("Electronics", "Devices and gadgets."),
                new("Household", "Household items and appliances."),
                new("Clothing", "Clothing for men, women and children."),
                new("Books", "Fiction, non-fiction, educational and more."),
                new("Toys & Games", "Toys for kids, board games and puzzles.")
            };
            _categoryDictionary = _categories.ToDictionary(c => c.CategoryName);  // Store categories in a dictionary for easy lookup by category name
        }

        // Initializes products with categories, descriptions, and prices
        private void InitializeProducts()
        {
            _products = new List<Product>
            {
                // Adding several sample products
                new("LED TV", "65 inch Samsung LED TV", 459.99f, 5, 1),
                new("Vacuum Cleaner", "Dyson V11 Vacuum Cleaner", 599.99f, 10, 2),
                new("Running Shoes", "Nike Air Zoom Pegasus", 120.00f, 20, 3),
                new("Software Programming", "C# for beginners", 12.99f, 25, 4),
                new("Blender", "NutriBullet Pro", 89.99f, 15, 2),
                new("Smartphone", "iPhone 13", 999.99f, 8, 5)
            };
            _productDictionary = _products.ToDictionary(p => p.ProductName);  // Store products in a dictionary for easy lookup by product name
        }

        // Method to handle user login
        private void Login()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Online Shop!");
                Console.WriteLine("[1]: Customer Login");
                Console.WriteLine("[2]: Admin Login");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))  // Parse user input for login choice
                {
                    if (choice == 1)
                    {
                        AuthenticateUser(_customers, user => _currentCustomer = user, CustomerMenu);  // Authenticate as a customer
                    }
                    else if (choice == 2)
                    {
                        AuthenticateUser(_admins, user => _currentAdmin = user, AdminMenu);  // Authenticate as an admin
                    }
                    else
                    {
                        DisplayError("Invalid option. Try again.");
                    }
                }
                else
                {
                    DisplayError("Invalid input. Please enter a number.");
                }
            }
        }

        // Method to authenticate a user (either customer or admin)
        private void AuthenticateUser<T>(List<T> users, Action<T> setUser, Action nextMenu) where T : User
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{typeof(T).Name} Login");
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                // Search for the user by username and password
                var user = users.FirstOrDefault(u => u.UserUsername == username && u.UserPassword == password);
                if (user != null)
                {
                    setUser(user);  // Set the current user (either customer or admin)
                    Console.WriteLine($"Logged in as {username}. Press any key to continue...");
                    Console.ReadKey();
                    nextMenu();  // Display the appropriate menu for the user
                    return;
                }
                DisplayError("Invalid credentials. Try again.");
            }
        }

        // Displays the customer menu with options
        private void CustomerMenu()
        {
            ShowMenu("Customer Menu", new Dictionary<string, Action>
            {
                { "View Profile", ViewCustomerProfile },
                { "View Products", ViewProducts },
                { "View Basket", ViewBasket },
                { "Add Product to Basket", AddProductToBasket },
                { "Remove Product from Basket", RemoveProductFromBasket },
                { "Checkout", Checkout },
                { "Exit", ExitApplication }
            });
        }

        // Displays the admin menu with options
        private void AdminMenu()
        {
            ShowMenu("Admin Menu", new Dictionary<string, Action>
            {
                { "View Profile", ViewAdminProfile },
                { "View Products", ViewProducts },
                { "Add Product", AddProduct },
                { "Remove Product", RemoveProduct },
                { "Update Product", UpdateProduct },
                { "View Customers", ViewCustomers },
                { "Add Customer", AddCustomer },
                { "Remove Customer", RemoveCustomer },
                { "Update Customer", UpdateCustomer },
                { "Exit", ExitApplication }
            });
        }

        // Method to display a menu with choices and handle user input
        private void ShowMenu(string title, Dictionary<string, Action> options)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(title);
                foreach (var (key, index) in options.Keys.Select((key, index) => (key, index + 1)))
                {
                    Console.WriteLine($"[{index}]: {key}");  // Display each option in the menu
                }
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= options.Count)
                {
                    options.ElementAt(choice - 1).Value();  // Execute the chosen option
                }
                else
                {
                    DisplayError("Invalid option. Try again.");
                }
            }
        }

        // Helper method to display error messages
        private void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}");
            WaitForUser();  // Wait for the user to press a key before proceeding
        }

        // Helper method to wait for the user to press a key
        private void WaitForUser()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();  // Wait for user input before continuing
        }

        // Method to exit the application
        private void ExitApplication()
        {
            Console.WriteLine("Exiting application...");
            Environment.Exit(0);  // Exit the application
        }

        // Method to view the profile of the logged-in customer
        private void ViewCustomerProfile()
        {
            Console.Clear();
            _currentCustomer.ViewCustomer();  // Calls the customer’s method to display their profile
            WaitForUser();
        }

        // Method to view the profile of the logged-in admin
        private void ViewAdminProfile()
        {
            Console.Clear();
            _currentAdmin.ViewAdmin();  // Calls the admin’s method to display their profile
            WaitForUser();
        }

        // Method to view all available products
        private void ViewProducts()
        {
            Console.Clear();
            _products[0].ViewProducts(_products);  // Calls the method to display all products
            WaitForUser();
        }

        // Method to view the items in the shopping basket
        private void ViewBasket()
        {
            Console.Clear();
            _shoppingBasket.DisplayBasket();  // Calls the shopping basket’s method to display its contents
            WaitForUser();
        }

        // Method to add a product to the shopping basket
        private void AddProductToBasket()
        {
            Console.Clear();
            Console.Write("Enter Product ID to add: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = _products.FirstOrDefault(p => p.ProductId == productId);  // Find the product by its ID
                if (product != null)
                {
                    Console.Write("Enter quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))  // Validate the quantity input
                    {
                        _shoppingBasket.AddItem(product, quantity);  // Add the item to the basket
                        Console.WriteLine("Product added to basket.");
                    }
                    else
                    {
                        DisplayError("Invalid quantity.");
                    }
                }
                else
                {
                    DisplayError("Product not found.");
                }
            }
            else
            {
                DisplayError("Invalid Product ID.");
            }
            WaitForUser();
        }

        // Method to remove a product from the shopping basket
        private void RemoveProductFromBasket()
        {
            Console.Clear();
            Console.Write("Enter Product ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                _shoppingBasket.RemoveItem(productId);  // Removes the product from the basket
                Console.WriteLine("Product removed from basket.");
            }
            else
            {
                DisplayError("Invalid Product ID.");
            }
            WaitForUser();
        }

        // Method to checkout the items in the basket
        private void Checkout()
        {
            Console.Clear();
            var total = _shoppingBasket.GetTotalValue();  // Get the total value of items in the basket
            Console.WriteLine(total > 0
                ? $"Total basket value: {total:C}. Proceeding with checkout..."
                : "Your basket is empty. Add products before checkout.");
            WaitForUser();
        }

        // Method to add a new product to the shop
        private void AddProduct()
        {
            Console.Clear();
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();  // Ask for the product name

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();  // Ask for the product description

            Console.Write("Enter Price: ");
            if (!float.TryParse(Console.ReadLine(), out float price))  // Validate the price
            {
                DisplayError("Invalid price.");
                return;
            }

            Console.Write("Enter Stock Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int stock))  // Validate the stock quantity
            {
                DisplayError("Invalid stock quantity.");
                return;
            }

            Console.Write("Enter Category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))  // Validate the category ID
            {
                DisplayError("Invalid category ID.");
                return;
            }

            _products.Add(new Product(name, description, price, stock, categoryId));  // Add the product to the list
            Console.WriteLine("Product added successfully.");
            WaitForUser();
        }

        // Method to remove an existing product from the shop
        private void RemoveProduct()
        {
            Console.Clear();
            Console.Write("Enter Product ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))  // Validate the product ID input
            {
                DisplayError("Invalid Product ID.");
                return;
            }

            var product = _products.FirstOrDefault(p => p.ProductId == productId);  // Find the product by its ID
            if (product == null)
            {
                DisplayError("Product not found.");
                return;
            }

            _products.Remove(product);  // Remove the product from the list
            Console.WriteLine("Product removed successfully.");
            WaitForUser();
        }

        // Method to update an existing product in the shop
        private void UpdateProduct()
        {
            Console.Clear();
            Console.Write("Enter Product ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))  // Validate the product ID
            {
                DisplayError("Invalid Product ID.");
                return;
            }

            var product = _products.FirstOrDefault(p => p.ProductId == productId);  // Find the product by its ID
            if (product == null)
            {
                DisplayError("Product not found.");
                return;
            }

            Console.Write("New Name (leave blank to keep current): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) product.ProductName = name;  // Update the product name if provided

            Console.Write("New Description (leave blank to keep current): ");
            string description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description)) product.ProductDescription = description;  // Update the description if provided

            Console.Write("New Price (leave blank to keep current): ");
            if (float.TryParse(Console.ReadLine(), out float price)) product.ProductPrice = price;  // Update the price if provided

            Console.Write("New Stock (leave blank to keep current): ");
            if (int.TryParse(Console.ReadLine(), out int stock)) product.ProductStockQuantity = stock;  // Update the stock quantity if provided

            Console.Write("New Category ID (leave blank to keep current): ");
            if (int.TryParse(Console.ReadLine(), out int categoryId)) product.ProductCategoryId = categoryId;  // Update the category ID if provided

            Console.WriteLine("Product updated successfully.");
            WaitForUser();
        }

        // Method to view a list of all customers
        private void ViewCustomers()
        {
            Console.Clear();
            _customers[0].ViewCustomers(_customers);  // Calls the ViewCustomers method of the first customer
            WaitForUser();
        }

        // Method to add a new customer
        private void AddCustomer()
        {
            Console.Clear();
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();  // Ask for the username

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();  // Ask for the password

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();  // Ask for the email

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();  // Ask for the phone number

            Console.Write("Enter Street Address: ");
            string street = Console.ReadLine();  // Ask for the street address

            Console.Write("Enter City: ");
            string city = Console.ReadLine();  // Ask for the city

            Console.Write("Enter Status (Active/Inactive): ");
            string status = Console.ReadLine();  // Ask for the status

            Console.Write("Enter Role: ");
            string role = Console.ReadLine();  // Ask for the role

            _customers.Add(new Customer(username, password, email, phone, street, city, status, role));  // Add the customer to the list
            Console.WriteLine("Customer added successfully.");
            WaitForUser();
        }

        // Method to remove a customer from the system
        private void RemoveCustomer()
        {
            Console.Clear();
            Console.Write("Enter Username to remove: ");
            string username = Console.ReadLine();  // Ask for the username to remove

            var customer = _customers.FirstOrDefault(c => c.UserUsername == username);  // Find the customer by username
            if (customer == null)
            {
                DisplayError("Customer not found.");
                return;
            }

            _customers.Remove(customer);  // Remove the customer from the list
            Console.WriteLine("Customer removed successfully.");
            WaitForUser();
        }

        // Method to update an existing customer’s details
        private void UpdateCustomer()
        {
            Console.Clear();
            Console.Write("Enter Username to update: ");
            string username = Console.ReadLine();  // Ask for the username to update

            var customer = _customers.FirstOrDefault(c => c.UserUsername == username);  // Find the customer by username
            if (customer == null)
            {
                DisplayError("Customer not found.");
                return;
            }

            // Allows for updating each field with new information, leaving blank to keep current values
            Console.Write("New Username (leave blank to keep current): ");
            string newUsername = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newUsername)) customer.UserUsername = newUsername;  // Update the username

            Console.Write("New Password (leave blank to keep current): ");
            string newPassword = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPassword)) customer.UserPassword = newPassword;  // Update the password

            Console.Write("New Email (leave blank to keep current): ");
            string newEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newEmail)) customer.UserEmail = newEmail;  // Update the email

            Console.Write("New Phone (leave blank to keep current): ");
            string newPhone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPhone)) customer.UserPhone = newPhone;  // Update the phone number

            Console.Write("New Street Address (leave blank to keep current): ");
            string newStreet = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newStreet)) customer.UserAddressStreet = newStreet;  // Update the street address

            Console.Write("New City (leave blank to keep current): ");
            string newCity = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCity)) customer.UserAddressCity = newCity;  // Update the city

            Console.Write("New Status (leave blank to keep current): ");
            string newStatus = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newStatus)) customer.UserStatus = newStatus;  // Update the status

            Console.Write("New Role (leave blank to keep current): ");
            string newRole = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newRole)) customer.UserRole = newRole;  // Update the role

            Console.WriteLine("Customer updated successfully.");
            WaitForUser();
        }
    }
}
