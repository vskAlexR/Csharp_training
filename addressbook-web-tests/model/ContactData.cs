using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName = "";
        private string mobileNumber = "";
        private string allPhones;


        public ContactData(string firstName)
        {
            this.firstName = firstName;
        }

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public ContactData(string firstName, string lastName, string mobileNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.mobileNumber = mobileNumber;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return this.ToString() == other.ToString();
        }

        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + "_" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return this.ToString().CompareTo(other.ToString());
        }

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string MobileNumber { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}