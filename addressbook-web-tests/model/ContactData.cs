using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string mobileNumber;
        private string allPhones;
        private string allEmails;
        private string allContactInfo;
        private string fullName;

        public ContactData() { }

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
        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }
        public string HomePage { get; set; }



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
        private string PhoneCleanUp(string phone)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                if (phone == HomePhone) { phone = "H: " + HomePhone + "\r\n"; }
                else if (phone == WorkPhone) { phone = "W: " + WorkPhone + "\r\n" + "\r\n"; }
                else if (phone == MobilePhone) { phone = "M: " + MobilePhone + "\r\n"; }
            }
            return phone;
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (EmailCleanUp(Email) + EmailCleanUp(Email2) + EmailCleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        private string EmailCleanUp(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ ]", "") + "\r\n";
        }

        public string AllContactInfo
        {
            get
            {
                if (allContactInfo != null)
                {
                    return allContactInfo;
                }
                else
                {
                    string fullName = FullName();
                    string address = AddressCleanUp();
                    string phones = PhoneCleanUp(HomePhone) + PhoneCleanUp(MobilePhone) + PhoneCleanUp(WorkPhone);
                    return  fullName + address + phones + AllEmails;
                   // return contactDetails;
                }
            }
            set { allContactInfo = value; }
        }

        public string FullName()
        {
            if (FirstName != null && LastName != null)
            {
                return  fullName = (FirstName + " " + LastName + "\r\n");
            }
            else
            {
                return fullName = (FirstName + LastName + "\r\n");
            }
        }
        private string AddressCleanUp()
        {
            if (Address != null && Address != "")
            {
                return Address + "\r\n" + "\r\n";
            }
            else
            {
                return "\r\n";
            }
        }
    }
}