using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGreatSelenium.NonPageObjects
{
    internal class User
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Country { get; set; }
        public String Password { get; set; }
        public String RealAccount { get; set; }
        public User() 
        {
            String randStr = DataPicker.GenerateRandomString(10, "abcdefghijklmnopqrstuvwxyz");
            FirstName = "TestFNAME" + randStr;
            randStr = DataPicker.GenerateRandomString(10, "abcdefghijklmnopqrstuvwxyz");
            LastName = "TestLNAME" + randStr;
            randStr = DataPicker.GenerateRandomString(10, "abcdefghijklmnopqrstuvwxyz0123456789");
            Email = randStr + "@mailinator.com";
        }
    }
}
