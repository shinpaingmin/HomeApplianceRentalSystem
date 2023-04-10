using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRentalSystem
{
    public class UserAccounts   // Must be declared with "pulic class" to be able to use in different forms
    {
        private String name;
        private String password;

        public UserAccounts(string n, string p)
        {
            name = n;
            password = p;
        }
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
