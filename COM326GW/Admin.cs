using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW
{
    public class Admin : User
    {
        private DateTime _adminLastLogin;

        public Admin(string userUsername, string userPassword, string userEmail, string userPhone, string userAddressStreet, string userAddressCity, DateTime adminLastLogin) : base(userUsername, userPassword, userEmail, userPhone, userAddressStreet, userAddressCity)
        {
            _adminLastLogin = adminLastLogin;
        }

        public DateTime AdminLastLogin { get => _adminLastLogin; set => _adminLastLogin = value; }

        // Viewing admin
        public void ViewAdmin()
        {
            int width = 15;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Global.Format("Username:", width)}{Global.LightGreen}{UserUsername}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Password:", width)}{Global.LightGreen}{UserPassword}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Email:", width)}{Global.LightGreen}{UserEmail}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Phone:", width)}{Global.LightGreen}{UserPhone}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Address:", width)}{Global.LightGreen}{UserAddressStreet}{Global.Reset}, {Global.LightGreen}{UserAddressCity}{Global.Reset}\n");
            sb.AppendLine($"{Global.Format("Last Login:", width)}{Global.LightGreen}{AdminLastLogin}{Global.Reset}\n");

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
