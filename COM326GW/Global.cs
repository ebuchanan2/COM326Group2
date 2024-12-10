using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW
{
    public class Global
    {
        // Global colour variables
        public static string Reset = "\u001B[0m";
        public static string LightGreen = "\u001B[92m";
        public static string LightRed = "\u001B[91m";

        // Global formatting for methods (for example, ViewCustomer() in Customer.cs
        public static string Format(string label, int width)
        {
            return label.PadRight(width);
        }
    }
}
