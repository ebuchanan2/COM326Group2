using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM326GW
{
    public class User
    {
        private static int _nextUserId = 1;

        private int _userId;
        private string _userUsername;
        private string _userPassword;
        private string _userEmail;
        private string _userPhone;
        private string _userAddressStreet;
        private string _userAddressCity;

        public User(string userUsername, string userPassword, string userEmail, string userPhone, string userAddressStreet, string userAddressCity)
        {
            _userId = _nextUserId++;
            _userUsername = userUsername;
            _userPassword = userPassword;
            _userEmail = userEmail;
            _userPhone = userPhone;
            _userAddressStreet = userAddressStreet;
            _userAddressCity = userAddressCity;
        }

        public int UserId { get => _userId; set => _userId = value; }
        public string UserUsername { get => _userUsername; set => _userUsername = value; }
        public string UserPassword { get => _userPassword; set => _userPassword = value; }
        public string UserEmail { get => _userEmail; set => _userEmail = value; }
        public string UserPhone { get => _userPhone; set => _userPhone = value; }
        public string UserAddressStreet { get => _userAddressStreet; set => _userAddressStreet = value; }
        public string UserAddressCity { get => _userAddressCity; set => _userAddressCity = value; }
    }
}
