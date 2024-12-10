using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW
{
    public class Customer : User
    {
        private string _userStatus;
        private string _userRole;

        public Customer(string userUsername, string userPassword, string userEmail, string userPhone, string userAddressStreet, string userAddressCity, string userStatus, string userRole) : base(userUsername, userPassword, userEmail, userPhone, userAddressStreet, userAddressCity)
        {
            _userStatus = userStatus;
            _userRole = userRole;
        }

        public string UserStatus { get => _userStatus; set => _userStatus = value; }
        public string UserRole { get => _userRole; set => _userRole = value; }

        // Viewing a customer list
        public void ViewCustomers(List<Customer> customers)
        {
            if (customers.Count <= 0)
            {
                Console.WriteLine("No customers to view. Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Customers:\n");

            // Show each customer
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"[{customer.UserId}]: {customer.UserUsername}");
            }

            Console.Write("\nTo view a customer, enter the customer id: ");
            string input = Console.ReadLine();

            // Parse the input
            if (int.TryParse(input, out int intInput))
            {
                var selectedCustomer = customers.FirstOrDefault(c => c.UserId == intInput);

                if (selectedCustomer != null)
                {
                    Console.Clear();

                    selectedCustomer.ViewCustomer();
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

        // Viewing a specified customer
        public void ViewCustomer()
        {
            int width = 15;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Global.Format("Username:", width)}{Global.LightGreen}{UserUsername}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Password:", width)}{Global.LightGreen}{UserPassword}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Email:", width)}{Global.LightGreen}{UserEmail}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Phone:", width)}{Global.LightGreen}{UserPhone}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Address:", width)}{Global.LightGreen}{UserAddressStreet}{Global.Reset}, {Global.LightGreen}{UserAddressCity}{Global.Reset}\n");

            string statusColour;

            if (UserStatus == "Active")
            {
                statusColour = Global.LightGreen;
            }
            else
            {
                statusColour = Global.LightRed;
            }

            sb.AppendLine($"{Global.Format("Status:", width)}{statusColour}{UserStatus}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Role:", width)}{Global.LightGreen}{UserRole}{Global.Reset}\n");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
