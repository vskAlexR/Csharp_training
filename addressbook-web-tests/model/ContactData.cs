using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData
    {
        private string firstName;
        private string lastName = "";
        private string mobileNumber = "";

        public ContactData(string firstname)
        {
            this.firstName = firstname;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string MobileNumber
        {
            get
            {
                return mobileNumber;
            }
            set
            {
                mobileNumber = value;
            }
        }
    }
}